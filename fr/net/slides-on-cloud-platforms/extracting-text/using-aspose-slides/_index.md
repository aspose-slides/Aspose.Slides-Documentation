---
title: "Comment extraire du texte de PPT, PPTX et ODP avec Aspose.Slides"
linktitle: Diapositives
type: docs
weight: 30
url: /fr/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- plateformes cloud
- intégration cloud
- extraction de texte
- extraire le texte
- PPT
- PPTX
- ODP
- fichiers de présentation
- multiplateforme
- indépendant d'Office
- notes et commentaires
- indexation d'entreprise
- enrichissement des données
- .NET
- Aspose.Slides
description: "Extraire le texte des présentations sur les principales plateformes cloud à l'aide des API Aspose.Slides, automatisant la recherche, l'analyse et l'exportation pour PPT, PPTX et ODP."
---

## **Introduction**

Aspose.Slides fournit une **API puissante et de haut niveau** pour extraire du texte des fichiers de présentation, y compris **PPT, PPTX et ODP**. Contrairement à l'Open XML SDK — qui ne prend en charge que PPTX et implique une analyse XML complexe — Aspose.Slides simplifie l'extraction de texte, vous permettant de vous concentrer sur l'intégration du contenu extrait dans vos flux de travail.

## **Extraction rapide de texte avec PresentationFactory.Instance.GetPresentationText**

Pour extraire du texte d'une présentation, l'**API Aspose.Slides** propose la méthode statique `PresentationFactory.Instance.GetPresentationText`. Elle comprend plusieurs surcharges pour travailler avec un fichier de présentation ou un flux de données, capturant le texte des **diapositives, diapositives maîtres, mises en page, notes et commentaires**. Le texte extrait est accessible via l'interface `IPresentationText`.

Example usage:
```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```


## **Modes de fonctionnement pour GetPresentationText**

La méthode `GetPresentationText` dans `PresentationFactory` vous permet d'ajuster finement l'extraction de texte à l'aide du paramètre `TextExtractionArrangingMode`, qui contrôle la façon dont le texte est organisé dans la sortie.

### **Modes disponibles**

- **TextExtractionArrangingMode.Unarranged** – Extrait le texte de manière libre, en ignorant la mise en page originale de la diapositive.  
- **TextExtractionArrangingMode.Arranged** – Préserve l'ordre du texte selon son emplacement sur chaque diapositive.

Usage example:
```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```


## **Principaux avantages des méthodes PresentationFactory**

- **Pas besoin de charger des présentations entières** : minimise la consommation de mémoire et augmente la vitesse de traitement.  
- **Optimisé pour les gros fichiers** : gère efficacement même les présentations volumineuses, en extrayant le texte rapidement.  
- **Récupère les notes et commentaires** : inclut les annotations des utilisateurs pour une couverture complète du contenu.  
- **Idéal pour l'indexation et l'analyse de contenu** : parfait pour les systèmes d'entreprise nécessitant un traitement automatisé et un enrichissement des données.  
- **Indépendant d'Office** : fonctionne sans Microsoft PowerPoint installé, offrant une solution véritablement autonome.  
- **Prise en charge multi‑format** : fonctionne sans problème avec **PPT, PPTX et ODP**.  
- **API flexible et puissante** : fournit des méthodes polyvalentes pour l'extraction de texte structurée.  
- **Couverture complète des diapositives** : extrait le texte des **mises en page, diapositives maîtres, diapositives standard, arrière‑plans, notes du présentateur et commentaires**.  
- **Compatibilité multiplateforme** : fonctionne sous **Windows, Linux, macOS** et dans les environnements cloud.  
- **Performance élevée et évolutivité** : adaptée aux **applications SaaS** et aux déploiements d'entreprise à grande échelle.

## **Systèmes d'exploitation pris en charge**

Aspose.Slides fonctionne sur une variété de systèmes d'exploitation :

- **Windows** (par ex., Windows 7, 8, 10, 11 et éditions Server)  
- **Linux** (diverses distributions, y compris Ubuntu, Debian, Fedora, CentOS, etc.)  
- **macOS** (y compris les versions modernes comme 10.15 Catalina et suivantes)  

## **Langages de programmation pris en charge**

Aspose.Slides s'intègre à plusieurs plates‑formes et langages :

- **C#** – principalement pris en charge via Aspose.Slides pour .NET.  
- **Java** – API complète disponible avec Aspose.Slides pour Java.  
- **C++** – exploitez Aspose.Slides pour les applications C++ critiques en termes de performances.  
- **Python via .NET** – intégrez la fonctionnalité Aspose.Slides en utilisant l'interopérabilité .NET.  
- **Autres langages compatibles .NET** – utilisez la bibliothèque dans tout environnement pris en charge par .NET.  

## **Conclusion**

Aspose.Slides offre une **extraction de texte complète** pour les présentations PowerPoint et OpenDocument, prenant en charge **une variété de formats de fichiers, une structuration intuitive du texte et une mise en œuvre simple** comparée à l'Open XML SDK. Des **diapositives et notes au contenu des modèles**, **Aspose.Slides** est une solution à haute efficacité et riche en fonctionnalités pour l'extraction et la gestion du texte des présentations.