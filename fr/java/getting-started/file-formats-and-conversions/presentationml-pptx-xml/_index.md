---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /fr/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML est le nom d’une famille de formats basés sur XML pour les documents de présentation. Office OpenXML (OOXML) est le format basé sur XML introduit dans les applications Microsoft Office 2007. Office OpenXML est un format conteneur pour plusieurs langages de balisage spécialisés basés sur XML. PresentationML est le langage de balisage utilisé par Microsoft Office PowerPoint 2007 pour stocker les documents.

{{% /alert %}} 

## **PresentationML dans Aspose.Slides pour Java**
Les documents OOXML PresentationML sont fournis sous forme de fichiers PPTX, des packages XML compressés qui respectent la spécification [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides pour Java prend en charge de manière exhaustive la création, la lecture, la manipulation et l’écriture de documents PresentationML. De plus, Aspose.Slides pour Java est capable d’exporter les documents PresentationML vers un format de document largement utilisé comme le PDF. Cela est possible parce qu’Aspose.Slides pour Java a été conçu dans le but de gérer de façon exhaustive les documents de présentation et que PresentationML contient essentiellement la représentation interne des documents sous forme d’un package XML compressé.

**Un document PPTX généré par Aspose.Slides pour Java et ouvert dans Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Visualisation du même document PPTX généré par Aspose.Slides pour Java dans un ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML est ouvert, pourquoi utiliser Aspose.Slides pour Java ?**
Étant donné que PresentationML est basé sur XML, il est tout à fait possible de créer des applications pour traiter et générer des documents PresentationML en utilisant des classes XML sans dépendre d’une bibliothèque tierce telle qu’Aspose.Slides pour Java. Cependant, plusieurs avantages existent à utiliser Aspose.Slides pour Java plutôt que des classes XML lors de la manipulation de documents PresentationML.

La spécification OOXML compte plusieurs milliers de pages, de sorte que, pour gérer correctement les documents PresentationML, il faut consacrer beaucoup de temps et d’efforts à comprendre le format. En revanche, avec Aspose.Slides pour Java, il suffit d’utiliser des classes ainsi que leurs méthodes et propriétés pour effectuer des opérations qui paraissent complexes lorsqu’elles sont réalisées via des classes XML.

Certaines des fonctionnalités offertes par Aspose.Slides ne sont même pas disponibles lorsque vous travaillez avec des documents PresentationML via des classes XML :

- Exporter des documents PPT au format PDF.
- Rendre une diapositive dans n’importe quel format d’image pris en charge par le Framework Java.
- Copier automatiquement les masques d’une présentation source à l’aide de la fonction de clonage.
- Appliquer une protection aux formes.

Voici un exemple de document PresentationML contenant une seule diapositive avec une zone de texte contenant le texte «Hello World». Pour lire le texte à l’aide de classes XML, vous devez écrire un programme capable d’analyser ce texte simple à partir du fragment suivant. Aspose.Slides le fait pour vous.

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
```