---
title: Intégration d'Aspose.Slides avec Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /fr/net/integrating-aspose-slides-with-google-slides/
keywords:
- plateformes cloud
- intégration cloud
- Google Slides
- Google Drive
- Google API
- Google Service Account
- intégration SaaS
- OAuth 2.0
- PPT en PDF
- automatisation PowerPoint
- traitement de présentations
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Connectez Aspose.Slides avec Google Slides pour importer, synchroniser et convertir des présentations, automatiser les flux de travail, et conserver PowerPoint et OpenDocument dans une même chaîne."
---

# Intégration d'Aspose.Slides avec Google Slides

Aspose.Slides propose désormais une intégration avec Google Slides et Google Drive via son [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). Cette intégration permet aux applications .NET de convertir, modifier, télécharger et téléverser des présentations Google Slides.

## Qu'est-ce que Google Slides?
[Google Slides](https://workspace.google.com/products/slides/) est un logiciel de présentation gratuit et basé sur le Web développé par Google. Il permet aux utilisateurs de créer, modifier et partager des présentations de diapositives en ligne, similaire à Microsoft PowerPoint. Il prend en charge la collaboration en temps réel, le stockage cloud et fonctionne sur tout appareil disposant d'un accès Internet.

## API Google
Avant de commencer à travailler avec votre présentation Google Slides via Aspose.Slides, vous devez créer un projet Google API et créer un [projet Google Cloud](https://developers.google.com/workspace/guides/create-project), puis activer les API souhaitées.

Ensuite, vous devez choisir la méthode d'accès à l'API Google - [Aspose.SlideS Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) prend en charge deux manières d'accéder à l'API Google :
- `Google Service Account`
- `OAuth 2.0` avec interaction utilisateur via un navigateur.

### Compte de service Google
Un compte de service est un compte Google spécial utilisé par les applications ou les serveurs pour accéder aux API Google de manière programmatique sans interaction utilisateur. Il est couramment utilisé pour les systèmes back-end ou les tâches automatisées. Les comptes de service sont authentifiés à l'aide d'un fichier de clé JSON et disposent de leur propre adresse e-mail. Ils peuvent se voir attribuer des autorisations spécifiques via [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) et sont souvent utilisés avec des API telles que Google Drive, Sheets ou BigQuery pour un accès sécurisé et automatisé aux ressources.

### OAuth 2.0
Une autre façon courante d'accéder aux API Google est via OAuth 2.0 avec interaction utilisateur via un navigateur. Dans ce flux, l'utilisateur est redirigé vers une page de connexion Google où il accorde l'autorisation à l'application. Après approbation, l'application reçoit un code d'autorisation qu'elle échange contre un jeton d'accès et un jeton de rafraîchissement.

Le jeton d'accès permet un accès temporaire aux API Google, tandis que le jeton de rafraîchissement peut être stocké et réutilisé pour obtenir de nouveaux jetons d'accès sans que l'utilisateur ait à se reconnecter. Cela signifie que l'interaction via le navigateur n'est requise qu'une seule fois, rendant les accès ultérieurs aux API totalement automatisés. Cette méthode est généralement utilisée pour les applications qui doivent accéder aux données d'un utilisateur (comme Gmail, Calendar ou Drive) avec le consentement de l'utilisateur.

## Codons
Tout d'abord, ajoutez le package NuGet [Aspose.Slides SaaS Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) à votre projet:
```
dotnet add package Aspose.Slides.SaaSIntegrations
```


### Exemple 1
Dans l'exemple suivant, nous téléchargerons une présentation Google Slides depuis Google Drive et l'enregistrerons sur le disque local au format PDF. Nous utiliserons un compte de service Google pour l'autorisation, en supposant que le fichier JSON du compte de service contenant les identifiants a déjà été téléchargé.
```csharp
// Créez un HttpClient géré en externe
HttpClient httpClient = new HttpClient();

// Créez un fournisseur d'autorisation à l'aide d'un fichier JSON de compte de service
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Initialisez le service d'intégration Google Slides avec le fournisseur d'autorisation
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Chargez une présentation depuis Google Drive via son ID de fichier dans une instance IPresentation d'Aspose.Slides
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Modifiez la présentation si nécessaire (par exemple, supprimez la deuxième diapositive)
pres.Slides.RemoveAt(1);

// Enregistrez la présentation localement au format PDF
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```


Pour plus de commodité, Aspose.Slides SaaS Integration propose une méthode pour lister tous les fichiers accessibles à l'utilisateur. Les données retournées comprennent le nom du fichier, le type MIME et l'ID du fichier.
```csharp
// Obtenez la liste des fichiers disponibles pour le compte de service fourni
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```


Une autre façon de trouver l'ID du fichier est d'ouvrir la présentation dans l'application Web Google Slides et de le repérer dans l'URL.

Par exemple, dans l'URL suivante :
```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```


L'ID du fichier est :
```
1A2B3C4D5E6F7G8H9I0J
```


## Exemple 2
Dans l'exemple suivant, nous créerons une présentation PowerPoint à partir de zéro et la téléverserons sur Google Drive au format Google Slides. Pour l'autorisation, nous utiliserons OAuth 2.0.
```csharp
// Créez un HttpClient géré en externe
HttpClient httpClient = new HttpClient();

// Créez un fournisseur d'autorisation en utilisant OAuth avec l'ID client et le secret client
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Initialise le service d'intégration Google Slides avec le fournisseur d'autorisation
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Créez une présentation d'exemple
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Enregistrez la présentation dans le dossier racine de Google Drive au format Google Slides
    // Vous pouvez également choisir tout autre format d'exportation pris en charge par Aspose.Slides
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```


Si vous utilisez ce type d'autorisation dans votre application, `interaction avec le navigateur est requise`. Vous devrez sélectionner votre compte et confirmer que vous autorisez l'application à accéder à l'API Google Drive. C'est tout — cette opération n'est requise que lors du premier lancement.

### Exemple 3
Dans l'exemple suivant, nous utiliserons un jeton d'accès pré-obtenu. `GoogleAccessTokenAuthProvider` est une implémentation de l'interface `IGoogleAuthorizationProvider` qui utilise un jeton d'accès OAuth 2.0 existant pour autoriser les requêtes aux API Google. Contrairement aux fournisseurs qui initient ou gèrent le flux OAuth, cette classe dépend de l'appelant pour fournir un jeton d'accès valide.

Ce fournisseur est utile dans les systèmes où le jeton d'accès est obtenu de manière externe - généralement par une application frontale ou un autre service - et transmis au back-end. Il est particulièrement adapté aux environnements distribués où la gestion des jetons de rafraîchissement côté serveur introduit une complexité ou un risque d'invalidation du jeton en raison de tentatives de rafraîchissement concurrentes.

Cet exemple montre comment remplacer un fichier et mettre à jour son nom sur Google Drive tout en conservant son ID de fichier.
```csharp
// Créez un client HTTP pour effectuer des requêtes
using HttpClient httpClient = new HttpClient();

// Configurez l'authentification Google Drive à l'aide d'un jeton d'accès
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Initialisez l'intégration avec Google Slides/Drive en utilisant l'authentification et le client HTTP
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Créez une présentation d'exemple en utilisant Aspose.Slides
using (var presentation = new Presentation())
{
    // Ajoutez une forme rectangle à la première diapositive et définissez son texte
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Définissez les options de sauvegarde PDF avec des paramètres de qualité et de conformité spécifiques
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Enregistrez (remplacez) le fichier existant sur Google Drive par ID, mettez à jour son nom et exportez en PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID du fichier existant sur Google Drive
        GoogleSaveFormatType.Pdf,         // Format souhaité pour l'enregistrement
        saveOptions,           
        "NewFileName.pdf"                 // Nouveau nom à attribuer au fichier
    );
}
```


## Résumé
Aspose.Slides prend désormais en charge un format de fichier supplémentaire pour la gestion, simplifiant l'automatisation des flux de travail cloud pour créer, partager et modifier des présentations.

Cet article a présenté les fonctionnalités de base. Vous pouvez également enregistrer des fichiers dans des sous-dossiers, remplacer des fichiers existants et exporter vers Google Drive dans divers formats - sans vous limiter aux présentations Google Slides.

Aspose.Slides SaaS Integration continuera d'étendre la prise en charge des plateformes SaaS de présentation, revenez donc pour les mises à jour futures.

## FAQ

**Q: Dois-je un compte Google Workspace pour utiliser cette intégration?**  
Non. Vous pouvez utiliser soit un compte Google gratuit, soit un compte Google Workspace. L'accès requis dépend de vos autorisations sur Google Drive et Slides.

**Q: Quelle méthode d'authentification devrais-je choisir—Service Account ou OAuth 2.0?**  
Utilisez un **Service Account** pour les flux back-end ou automatisés sans interaction utilisateur.  
Utilisez **OAuth 2.0** si vous devez accéder aux fichiers Google Slides ou Drive d'un utilisateur spécifique avec son consentement.

**Q: Puis-je travailler avec des formats autres que Google Slides?**  
Oui. Aspose.Slides permet d'enregistrer les présentations dans divers formats (par ex., PDF, PPTX, HTML) avant de les téléverser sur Google Drive.

**Q: Comment obtenir l'ID du fichier d'une présentation Google Slides?**  
Vous pouvez le récupérer en utilisant la méthode `GetDriveFileInfosAsync()` ou en le copiant depuis l'URL de la présentation dans Google Slides.

**Q: L'intégration prend-elle en charge le remplacement d'un fichier existant sur Google Drive?**  
Oui. Utilisez la méthode `SavePresentationToExistingFileAsync` pour mettre à jour un fichier tout en conservant son ID.

**Q: L'interaction avec le navigateur est-elle requise à chaque fois lors de l'utilisation d'OAuth 2.0?**  
Non. L'interaction via le navigateur n'est requise que lors de la première autorisation. Par la suite, les jetons de rafraîchissement stockés permettent un accès automatisé.