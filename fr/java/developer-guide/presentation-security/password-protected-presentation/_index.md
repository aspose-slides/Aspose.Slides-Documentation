---
title: Protéger les présentations par mot de passe en Java
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/java/password-protected-presentation/
keywords:
- présentation protégée par mot de passe
- mot de passe d'ouverture
- chiffrer PowerPoint
- décrypter PowerPoint
- valider le mot de passe de la présentation
- vérifier le mot de passe de la présentation
- ouvrir une présentation chiffrée
- supprimer le chiffrement
- PowerPoint
- PPT
- PPTX
- présentation
- Java
- Aspose.Slides
description: "Chiffrer, détecter, valider, ouvrir et décrypter des présentations PowerPoint PPT et PPTX protégées par mot de passe en Java avec Aspose.Slides."
---
## **Vue d'ensemble**

Un mot de passe d'ouverture chiffre une présentation. Le mot de passe correct est nécessaire pour charger et visualiser le contenu de la présentation, ce qui garantit la confidentialité.

Un mot de passe d'ouverture est différent d'un mot de passe de protection en écriture. La protection en écriture restreint la modification mais ne chiffre pas le contenu et n'empêche pas le chargement de la présentation. Pour gérer les mots de passe de modification des présentations, voir [Protéger les présentations en écriture](/slides/fr/java/write-protected-presentation/).

Les flux de travail ci-dessous s'appliquent aux présentations PPT et PPTX. Les exemples utilisent les deux formats lorsque leur comportement basé sur les fichiers ou les flux est important.

## **Chiffrer une présentation avec un mot de passe d'ouverture**

Utilisez [IProtectionManager.encrypt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) pour attribuer un mot de passe d'ouverture. Ensuite, utilisez [IPresentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) pour enregistrer la présentation chiffrée.

L'exemple suivant chiffre une présentation PPTX :
```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Conserver les propriétés du document publiques**

Par défaut, Aspose.Slides inclut les propriétés du document dans le chiffrement de la présentation. La méthode [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) contrôle ce comportement indépendamment du chiffrement du contenu des diapositives. Passez `false` avant d'appeler [IProtectionManager.encrypt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) lorsqu'un système d'indexation, de classification, de recherche ou de gestion de documents doit lire les métadonnées sans le mot de passe d'ouverture.

L'exemple suivant crée une présentation PPTX chiffrée tout en laissant ses propriétés de document intégrées publiques :
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Passer `false` à [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ne rend pas publiques les diapositives, les maîtres, les mises en page, les formes, les médias ou tout autre contenu de la présentation. Cela n'affecte que les propriétés du document. Pour lire ces propriétés sans charger le contenu chiffré, voir [Gérer les propriétés de la présentation](/slides/fr/java/presentation-properties/).

## **Charger une présentation chiffrée**

Définissez [ILoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) avec le mot de passe d'ouverture et transmettez les options à [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) lors du chargement du fichier. Le chargement échoue lorsqu'un mot de passe d'ouverture est requis mais que le mot de passe fourni est absent ou incorrect.
```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Travailler avec la présentation déchiffrée.
} finally {
    presentation.dispose();
}
```

## **Supprimer le chiffrement d'une présentation**

Chargez la présentation avec son mot de passe d'ouverture, appelez [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) puis enregistrez le résultat. La présentation enregistrée peut alors être chargée sans mot de passe.
```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Valider un mot de passe d'ouverture avant le chargement**

Utilisez [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) pour obtenir [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/) sans créer une instance complète de présentation. Vérifiez [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) avant de demander ou de valider un mot de passe. Lorsque la protection est présente, validez la valeur fournie avec [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Flux de travail avec chemin de fichier**

L'exemple suivant valide un mot de passe d'ouverture pour un fichier PPTX, transmet la valeur validée à [ILoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), puis charge la présentation complète :
```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Flux de travail avec flux**

La surcharge flux de [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) fournit le même flux de travail. Réinitialisez la position d'un flux recherchable avant de charger la présentation complète à partir de ce flux.

L'exemple suivant utilise un fichier PPT :
```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Valeurs de retour de checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) renvoie `true` uniquement lorsque la présentation possède un mot de passe d'ouverture et que le mot de passe fourni est correct. Il renvoie `false` dans chacun de ces cas :
- Le mot de passe est incorrect.
- La présentation n'a pas de mot de passe d'ouverture.
- Le mot de passe fourni est `null` ou vide.

Le comportement est identique pour les présentations PPT et PPTX.

## **Vérifier si une présentation chargée est chiffrée**

Après avoir chargé une présentation avec le mot de passe correct, examinez [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) pour confirmer que la présentation source était chiffrée. Pour détecter la protection par mot de passe d'ouverture avant le chargement, utilisez `IPresentationInfo.isPasswordProtected` comme indiqué ci-dessous.
```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Recommandations de sécurité**

{{% alert color="warning" title="Sécurité" %}}
Ne consignez pas les mots de passe d'ouverture ni ne les incluez dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles, conservez les mots de passe en mémoire uniquement le temps nécessaire, et réutilisez un résultat de validation réussi lorsqu'il faut charger immédiatement la présentation.

Les propriétés publiques du document peuvent révéler les noms d'auteur, les titres, les sujets, les mots-clés, les informations de l'entreprise, les commentaires et les valeurs personnalisées même si le contenu de la présentation est chiffré. Chiffrez les métadonnées sensibles avec la présentation. Laisser les propriétés publiques doit être une décision explicite prise uniquement lorsque les systèmes doivent indexer, classifier, rechercher ou gérer le fichier sans un mot de passe d'ouverture.
{{% /alert %}}

## **Protéger une présentation par mot de passe en ligne**

1. Ouvrez l'application [Aspose.Slides Lock](https://products.aspose.app/slides/fr/lock).
1. Sélectionnez ou téléversez la présentation.
1. Saisissez un mot de passe pour la protection de la visualisation.
1. Saisissez éventuellement un mot de passe distinct pour la protection en écriture.
1. Appliquez la protection et téléchargez le fichier résultant.

{{% alert color="info" title="Voir aussi" %}}
- [Protéger les présentations en écriture](/slides/fr/java/write-protected-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Un mot de passe d'ouverture chiffre la présentation et est requis pour charger son contenu. Un mot de passe de protection en écriture restreint la modification sans chiffrer le contenu.

**Puis-je valider un mot de passe d'ouverture sans charger toutes les diapositives ?**

Oui. Obtenez les informations de la présentation, vérifiez si une protection par mot de passe d'ouverture est présente, et validez le mot de passe avant de créer une instance complète de la présentation.

**Une application peut‑elle lire les métadonnées sans le mot de passe d'ouverture ?**

Oui, mais uniquement lorsque la présentation a été chiffrée avec le chiffrement des propriétés du document désactivé. L'application doit alors utiliser le mode de chargement uniquement des propriétés du document décrit dans [Gérer les propriétés de la présentation](/slides/fr/java/presentation-properties/).

**Les flux de travail de vérification du mot de passe prennent‑ils en charge à la fois PPT et PPTX ?**

Oui. La détection et la validation du mot de passe basées sur le chemin de fichier ou le flux se comportent de la même manière pour les présentations PPT et PPTX.