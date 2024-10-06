---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /cpp/presentationml-pptx-xml/
---

## **À propos de PresentationML**
PresentationML est un nom désignant une famille de formats basés sur XML pour les documents de présentation. Office OpenXML (OOXML) est le format basé sur XML introduit dans les applications Microsoft Office 2007. Office OpenXML est un format conteneur pour plusieurs langages de balisage spécialisés basés sur XML. PresentationML est le langage de balisage utilisé par Microsoft Office PowerPoint 2007 pour stocker ses documents.
## **PresentationML dans Aspose.Slides pour C++**
Les documents PresentationML OOXML se présentent sous forme de fichiers PPTX qui sont des packages XML compressés suivant les spécifications de la [norme OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides pour C++ prend en charge de manière approfondie la création, la lecture, la manipulation et l'écriture de documents PresentationML. De plus, Aspose.Slides pour C++ est capable d'exporter des documents PresentationML vers différents formats de document largement utilisés comme PDF, TIFF et XPS. Cela est possible car Aspose.Slides pour C++ a été conçu dans le but de gérer de manière exhaustive les documents de présentation et PresentationML conserve essentiellement la présentation interne des documents sous forme de package XML compressé.

## **PresentationML est ouvert, pourquoi utiliser Aspose.Slides pour C++**
Étant donné que PresentationML est basé sur XML, il est tout à fait possible de créer des applications pour traiter et générer des documents PresentationML en utilisant des classes XML sans se fier à des bibliothèques de classes tierces comme Aspose.Slides pour C++. Cependant, il existe plusieurs avantages à utiliser Aspose.Slides pour C++ par rapport aux classes XML lors du travail avec des documents PresentationML.

La spécification OOXML est trop longue, comptant plusieurs milliers de pages. Cela signifie que, pour bien gérer les documents PresentationML, vous devrez consacrer beaucoup de temps et d'efforts à comprendre le format de ces documents. D'un autre côté, en utilisant Aspose.Slides pour C++, vous devez simplement utiliser les classes pertinentes et leurs méthodes / propriétés respectives pour effectuer des opérations qui semblent assez complexes si elles sont réalisées via des classes XML.

Voici quelques-unes des fonctionnalités qui ne sont même pas disponibles lorsque vous traitez des documents PresentationML via des classes XML :

- Exporter des documents PPT vers les formats PDF, TIFF, XPS
- Exporter des diapos dans les documents PPT vers les formats SVG
- Rendre une diapositive dans n'importe quel format d'image supporté par C++ Framework
- Copie automatique des modèles à partir de présentations source en utilisant la fonction de clonage
- Application de protection sur les formes

Prenons un exemple d'un document PresentationML contenant une seule diapositive avec une zone de texte contenant le texte «Hello World». Pour lire le texte via des classes XML, vous devrez écrire un programme capable d'analyser ce texte simple à partir du fragment suivant :
## **Exemple**

``` cpp

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