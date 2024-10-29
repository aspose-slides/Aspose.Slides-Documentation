---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /fr/php-java/presentationml-pptx-xml/
---

{{% alert color="primary" %}} 

PresentationML est un nom pour une famille de formats basés sur XML pour les documents de présentation. Office OpenXML (OOXML) est le format basé sur XML introduit dans les applications Microsoft Office 2007. Office OpenXML est un format conteneur pour plusieurs langages de balisage XML spécialisés. PresentationML est le langage de balisage utilisé par Microsoft Office PowerPoint 2007 pour stocker des documents.

{{% /alert %}} 

## **PresentationML dans Aspose.Slides pour PHP via Java**
Les documents PrésentationML OOXML viennent sous forme de fichiers PPTX, des packages XML compressés qui suivent la spécification [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides pour PHP via Java prend en charge de manière approfondie la création, la lecture, la manipulation et l'écriture de documents PresentationML. De plus, Aspose.Slides pour PHP via Java est capable d'exporter des documents PresentationML vers un format de document largement utilisé tel que PDF. Cela est possible car Aspose.Slides pour PHP via Java a été conçu dans le but de traiter de manière exhaustive les documents de présentation et PresentationML contient essentiellement la présentation interne des documents sous forme de package XML compressé.

**Un document PPTX généré par Aspose.Slides pour PHP via Java et ouvert dans Microsoft PowerPoint**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Visionnage du même document PPTX généré par Aspose.Slides pour PHP via Java dans un ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML est Ouvert, Pourquoi Utiliser Aspose.Slides pour PHP via Java ?**
Étant donné que PresentationML est basé sur XML, il est tout à fait possible de construire des applications pour traiter et générer des documents PresentationML en utilisant des classes XML sans se fier à une bibliothèque de classes tierce telle qu'Aspose.Slides pour PHP via Java. Cependant, il existe plusieurs avantages à utiliser Aspose.Slides pour PHP via Java par rapport aux classes XML lors du travail avec des documents PresentationML.

La spécification OOXML fait plusieurs milliers de pages, donc pour traiter correctement les documents PresentationML, vous devez passer beaucoup de temps et d'efforts à comprendre le format. En revanche, avec Aspose.Slides pour PHP via Java, vous utilisez simplement des classes et leurs méthodes et propriétés pour effectuer des opérations qui semblent complexes si elles sont effectuées via des classes XML.

Certaines des fonctionnalités offertes par Aspose.Slides ne sont même pas disponibles lorsque vous travaillez avec des documents PresentationML à travers des classes XML :

- Exporter des documents PPT au format PDF.
- Rendre une diapositive au format image pris en charge par le Java Framework.
- Copier automatiquement des maîtres à partir de présentations source en utilisant la fonctionnalité de clonage.
- Appliquer une protection sur des formes.

Voici un exemple d'un document PresentationML avec une seule diapositive contenant une zone de texte avec le texte "Hello World". Pour lire le texte à l'aide de classes XML, vous devez écrire un programme capable d'analyser ce texte simple à partir du fragment suivant. Aspose.Slides le fait pour vous.

**XML**

``` xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">
  <p:cSld>
    <p:spTree>
      <p:nvGrpSpPr>
        <p:cNvPr id="1" name=""/>
        <p:cNvGrpSpPr/>
        <p:nvPr/>
      </p:nvGrpSpPr>
      <p:grpSpPr>
        <a:xfrm>
          <a:off x="0" y="0"/>
          <a:ext cx="0" cy="0"/>
          <a:chOff x="0" y="0"/>
          <a:chExt cx="0" cy="0"/>
        </a:xfrm></p:grpSpPr><p:sp>
          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>
          <p:cNvSpPr txBox="1"/>
            <p:nvPr/>
          </p:nvSpPr>
          <p:spPr>
            <a:xfrm>
              <a:off x="2819400" y="2590800"/>
              <a:ext cx="1297086" cy="369332"/>
            </a:xfrm>
            <a:prstGeom prst="rect">
              <a:avLst/>
            </a:prstGeom>
            <a:noFill/>
          </p:spPr>
          <p:txBody>
            <a:bodyPr wrap="none" rtlCol="0">
              <a:spAutoFit/>
            </a:bodyPr>
            <a:lstStyle/>
            <a:p>
              <a:r>
                <a:rPr lang="en-US"/>
                <a:t>Hello World
                </a:t>
              </a:r>
              <a:endParaRPr lang="en-US"/>
            </a:p>
          </p:txBody>
        </p:sp>
    </p:spTree>
  </p:cSld>
  <p:clrMapOvr>
    <a:masterClrMapping/>
  </p:clrMapOvr>
</p:sld>
```php

```