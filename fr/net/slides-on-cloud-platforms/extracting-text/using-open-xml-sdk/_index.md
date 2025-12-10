---
title: "Comment extraire du texte des fichiers PPT, PPTX et ODP à l'aide d'Open XML SDK en .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /fr/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- plates-formes cloud
- intégration cloud
- Open XML SDK
- extraction de texte PPTX
- traitement de diapositives .NET
- extraction de texte de présentation
- diapositive maître
- notes du présentateur
- extraction de texte des diapositives
- C#
description: "Découvrez comment extraire du texte des fichiers PPT, PPTX et ODP en .NET avec Open XML SDK, en accédant au XML, avec des astuces de performance et des solutions de conversion pour les applications cloud."
---

## **Open XML SDK**

Le **Open XML SDK** fournit une méthode très structurée et efficace pour extraire du texte à partir de fichiers de présentation — en particulier les **PPTX**, qui respectent la norme Open XML. En offrant un accès direct au XML sous-jacent, ce SDK permet une manipulation plus rapide et plus souple du contenu des diapositives par rapport aux méthodes traditionnelles.

## **Accès direct au XML**

- **Analyser le texte directement** : Le Open XML SDK vous permet d'extraire le texte des parties XML sans rendre les diapositives.
- **Éléments structurés** : Parce que le texte est stocké dans des balises XML bien définies, il est plus simple de le récupérer et de le traiter.

### **Exemple : Extraction du texte directement à partir du contenu XML d’une diapositive**
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```


## **Avantages de performance**

- **Extraction plus rapide** : Contourne la surcharge d'ouverture de PowerPoint ou d'autres API de haut niveau.
- **Utilisation mémoire réduite** : Seules les parties XML pertinentes sont accédées, réduisant la consommation de ressources.
- **Pas besoin de Microsoft PowerPoint** : Vous libère des exigences d'installation supplémentaires.

### **Exemple : Extraction efficace du texte sans charger la présentation complète**
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```


## **Identification des éléments de texte**

### **Spécificités de l'extraction de texte à partir des présentations**

Lors de l'extraction de texte à partir de présentations, prenez en compte les facteurs suivants :

- **Le texte peut se trouver dans différentes sections** : Diapositives normales, diapositives maîtres, mises en page ou notes du présentateur.
- **Espaces réservés par défaut** : Les diapositives maîtres et les mises en page peuvent inclure des espaces réservés (p. ex., « Cliquez pour modifier le style du titre maître ») qui ne sont pas du contenu réel de la présentation.
- **Filtrer le texte vide ou masqué** : Certains éléments peuvent être vides ou ne pas être destinés à être affichés.

### **Balises contenant du texte**

Dans un fichier **PPTX**, le texte est généralement stocké dans :
- `<a:t>` à l'intérieur de `<a:p>` (paragraphes)
- `<a:r>` (segments de texte au sein des paragraphes)

### **Exemple : Extraction de tous les éléments de texte d’une diapositive**
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## **ODP et PPT**

### **Incapacité d'extraire du texte directement**

- Contrairement aux **PPTX**, les **PPT** (format binaire) et **ODP** (présentation OpenDocument) **ne sont pas pris en charge** par le Open XML SDK.
- Le **PPT** stocke le contenu dans un format binaire fermé, compliquant l'extraction du texte.
- L'**ODP** repose sur l'OpenDocument XML, qui diffère structurellement du PPTX.

### **Solution de contournement : conversion en PPTX**

Pour extraire du texte d’un **PPT** ou d’un **ODP**, l'approche recommandée est :

1. Convertir **PPT → PPTX** à l’aide de PowerPoint ou d’un outil tiers.  
2. Convertir **ODP → PPTX** via LibreOffice ou PowerPoint.  
3. Extraire le texte du nouveau **PPTX** en utilisant le Open XML SDK.

### **Exemple : Conversion d’ODP en PPTX via la ligne de commande LibreOffice**
```sh
soffice --headless --convert-to pptx presentation.odp
```


## **Plateformes et cadres pris en charge**

- **Windows** : .NET Framework 4.6.1 et supérieurs, .NET Core 2.1+, .NET 5/6/7.  
- **Linux/macOS** : .NET Core 2.1+, .NET 5/6/7.  
- **Environnements cloud** : Microsoft Azure Functions, AWS Lambda (.NET Core), conteneurs Docker.  
- **Compatibilité avec les applications Office** : aucune installation de Microsoft Office requise.  
- **Langages de programmation pris en charge** : le Open XML SDK peut être utilisé avec **C#**, **VB.NET**, **F#**, et d’autres langages supportés par .NET.

## **Conclusion**

Utiliser le **Open XML SDK** pour l'extraction de texte des **PPTX** offre à la fois efficacité et clarté, tandis que les **PPT** et **ODP** nécessitent une étape de conversion initiale pour un traitement fluide. Adopter cette approche garantit haute performance, flexibilité et large compatibilité avec les applications .NET modernes.