---
title: Examiner la présentation
type: docs
weight: 30
url: /fr/nodejs-java/examine-presentation/
keywords:
- PowerPoint
- présentation
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
- changer les propriétés
- modifier les propriétés
- PPTX
- PPT
- JavaScript
- Node
description: "Lire et modifier les propriétés d'une présentation PowerPoint dans Node"
---

Aspose.Slides for Node.js via Java vous permet d’examiner une présentation afin d’en connaître les propriétés et de comprendre son comportement.

{{% alert title="Info" color="info" %}} 

Les classes [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) et [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/) contiennent les propriétés et les méthodes utilisées dans les opérations présentées ici.

{{% /alert %}} 

## **Vérifier le format d’une présentation**

Avant de travailler sur une présentation, il peut être utile de déterminer le format (PPT, PPTX, ODP, etc.) dans lequel la présentation se trouve actuellement.

Vous pouvez vérifier le format d’une présentation sans la charger. Voir ce code JavaScript :
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```


## **Obtenir les propriétés d’une présentation**

Ce code JavaScript vous montre comment obtenir les propriétés d’une présentation (informations sur la présentation) :
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```


Vous voudrez peut‑être consulter les [propriétés sous la classe DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Mettre à jour les propriétés d’une présentation**

Aspose.Slides fournit la méthode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) qui vous permet de modifier les propriétés d’une présentation.

Imaginons que nous ayons une présentation PowerPoint avec les propriétés de document ci‑dessous.

![Original document properties of the PowerPoint presentation](input_properties.png)

Cet exemple de code montre comment modifier certaines propriétés de la présentation :
```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


Les résultats de la modification des propriétés de document sont présentés ci‑dessous.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Liens utiles**

Pour obtenir plus d’informations sur une présentation et ses attributs de sécurité, vous pouvez consulter les liens suivants :

- [Vérifier si une présentation est chiffrée](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une présentation est protégée en écriture (lecture seule)](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une présentation est protégée par mot de passe avant de la charger](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le mot de passe utilisé pour protéger une présentation](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Comment puis‑je vérifier si les polices sont incorporées et lesquelles ?**

Recherchez les informations sur les [polices incorporées](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) pour identifier les polices critiques pour le rendu.

**Comment puis‑je rapidement savoir si le fichier contient des diapositives masquées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) et inspectez le [drapeau de visibilité](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) de chaque diapositive.

**Puis‑je détecter si une taille et une orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Comparez la [taille de diapositive](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslidesize/) actuelle et son orientation avec les paramètres standard ; cela aide à anticiper le comportement lors de l’impression et de l’exportation.

**Existe‑t‑il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), et notez si les données sont internes ou liées, en incluant les liens cassés éventuels.

**Comment évaluer les diapositives « lourdes » qui pourraient ralentir le rendu ou l’exportation PDF ?**

Pour chaque diapositive, comptez les objets et repérez les images volumineuses, la transparence, les ombres, les animations et les médias ; attribuez un score de complexité approximatif afin de signaler les points de performance potentiels.