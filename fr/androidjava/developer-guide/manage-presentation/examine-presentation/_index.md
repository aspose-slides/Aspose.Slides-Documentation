---
title: Récupérer et mettre à jour les informations de présentation sous Android
linktitle: Informations sur la présentation
type: docs
weight: 30
url: /fr/androidjava/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir des propriétés
- lire les propriétés
- modifier les propriétés
- modifier les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument avec Java pour obtenir des analyses plus rapides et des audits de contenu plus intelligents."
---

Aspose.Slides for Android via Java vous permet d'examiner une présentation pour découvrir ses propriétés et comprendre son comportement.

{{% alert title="Info" color="info" %}} 
Les classes [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) et [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) contiennent les propriétés et les méthodes utilisées dans les opérations présentées ici.
{{% /alert %}} 

## **Vérifier le format d’une présentation**

Avant de travailler sur une présentation, vous souhaiterez peut‑être connaître le format (PPT, PPTX, ODP, etc.) de la présentation à ce moment‑ci.

Vous pouvez vérifier le format d’une présentation sans la charger. Voir ce code Java :
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```


## **Obtenir les propriétés d’une présentation**

Ce code Java vous montre comment obtenir les propriétés d’une présentation (informations sur la présentation) :
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```


Vous voudrez peut‑être consulter les [propriétés de la classe DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Mettre à jour les propriétés d’une présentation**

Aspose.Slides fournit la méthode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) qui vous permet de modifier les propriétés d’une présentation.

Supposons que nous ayons une présentation PowerPoint avec les propriétés du document présentées ci‑dessous.

![Propriétés du document d'origine de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment modifier certaines propriétés de la présentation :
```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


Les résultats de la modification des propriétés du document sont présentés ci‑dessous.

![Propriétés du document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir davantage d’informations sur une présentation et ses attributs de sécurité, vous trouverez peut‑être ces liens utiles :

- [Vérifier si une présentation est chiffrée](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une présentation est protégée en écriture (lecture seule)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une présentation est protégée par mot de passe avant de la charger](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le mot de passe utilisé pour protéger une présentation](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Comment vérifier si les polices sont intégrées et lesquelles le sont ?**  
Recherchez les [informations sur les polices intégrées](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) afin d’identifier les polices critiques pour le rendu.

**Comment déterminer rapidement si le fichier contient des diapositives masquées et combien ?**  
Parcourez la [collection de diapositives](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) et examinez le [drapeau de visibilité](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) de chaque diapositive.

**Puis‑je détecter si une taille et une orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**  
Oui. Comparez la [taille de diapositive](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) et l’orientation actuelles avec les paramètres standard ; cela vous aide à anticiper le comportement lors de l’impression et de l’exportation.

**Existe‑t‑il un moyen rapide de savoir si les graphiques font référence à des sources de données externes ?**  
Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) et notez si les données sont internes ou liées, y compris les liens rompus.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l’export PDF ?**  
Pour chaque diapositive, comptez le nombre d’objets et recherchez les images volumineuses, la transparence, les ombres, les animations et les médias ; attribuez un score de complexité approximatif afin d’identifier les points de performance potentiels.