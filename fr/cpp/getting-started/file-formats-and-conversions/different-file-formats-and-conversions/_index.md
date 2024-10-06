---
title: Différents formats de fichiers et conversions
type: docs
weight: 50
url: /cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **À propos de PPT**
[PPT](https://fr.wikipedia.org/wiki/Microsoft_PowerPoint) est le format de fichier de document de présentation qui peut être créé, lu, manipulé et écrit par différentes versions de Microsoft PowerPoint. C'est le format binaire pour les documents de présentation développé par Microsoft.
### **PPT dans Aspose.Slides pour C++**
Aspose.Slides pour C++ peut lire les fichiers PPT créés par les logiciels énumérés ci-dessous.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

De même, les fichiers PPT créés par Aspose.Slides pour C++ peuvent être lus par l'ensemble de logiciels ci-dessus.
### **Support complet pour PPT**
Aspose.Slides pour C++ fournit un support pour presque toutes les fonctionnalités liées au format de fichier de document PPT. Il couvre non seulement les fonctionnalités de base / avancées fournies par différentes versions de Microsoft PowerPoint pour les manipulations de documents PPT, mais également certaines fonctionnalités qui ne sont même pas prises en charge par Microsoft PowerPoint. L'avantage principal de l'utilisation de la bibliothèque API Aspose.Slides pour C++ est la facilité d'utilisation pour gérer de telles fonctionnalités.

En plus des tâches de base liées à la création, la lecture et l'écriture de fichiers de documents PPT, plusieurs fonctionnalités sont fournies par Aspose.Slides pour C++ telles que :

- Importer d'autres formats de fichiers MS Office en tant qu'objets OLE dans des documents PPT.
- Exporter des documents PPT vers PDF, TIFF, formats XPS.
- Exporter des diapositives dans les documents PPT vers des formats SVG.
- Rendre une diapositive dans n'importe quel format d'image supporté par C++ Framework.
- Définir la taille des diapositives dans le document PPT.
- Gérer les animations sur les formes.
- Gérer les diaporamas.
- Formatter le texte sur les diapositives.
- Scanner le texte des documents PPT.
- Gérer les tableaux sur les diapositives.
- Copie automatique des maître à l'aide de la fonction de clonage.

Un fichier PPT généré par Aspose.Slides pour C++ et ouvert dans Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **À propos de PresentationML**
PresentationML est un nom pour une famille de formats basés sur XML pour les documents de présentation. Office OpenXML (OOXML) est le format basé sur XML introduit dans les applications Microsoft Office 2007. Office OpenXML est un format conteneur pour plusieurs langages de balisage XML spécialisés. PresentationML est le langage de balisage utilisé par Microsoft Office PowerPoint 2007 pour stocker ses documents.
### **PresentationML dans Aspose.Slides pour C++**
Les documents OOXML PresentationML arrivent sous forme de fichiers PPTX qui sont des packages XML compressés suivant les spécifications [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides pour C++ prend en charge la création, la lecture, la manipulation et l'écriture de documents PresentationML. De plus, Aspose.Slides pour C++ est capable d'exporter des documents PresentationML vers différents formats de documents largement utilisés tels que PDF, TIFF et XPS. C'est possible car Aspose.Slides pour C++ a été conçu avec l'objectif de gérer de manière exhaustive les documents de présentation et PresentationML maintient essentiellement la présentation interne des documents sous forme de package XML compressé.

Un document PPTX généré par Aspose.Slides pour C++ et ouvert dans Microsoft PowerPoint

Visualisation d'un document PPTX généré par Aspose.Slides pour C++ dans une application Zip
### **PresentationML est ouvert, pourquoi utiliser Aspose.Slides pour C++**
Puisque PresentationML est basé sur XML, il est tout à fait possible de construire des applications pour traiter et générer des documents PresentationML en utilisant des classes XML sans dépendre de bibliothèques de classes tierces telles qu'Aspose.Slides pour C++. Cependant, il existe plusieurs avantages à utiliser Aspose.Slides pour C++ par rapport aux classes XML lors du travail avec des documents PresentationML.

La spécification OOXML est trop longue, comprenant plusieurs milliers de pages. Cela signifie que, pour bien gérer les documents PresentationML, vous devrez passer beaucoup de temps et d'efforts à comprendre le format de tels documents. D'un autre côté, en utilisant Aspose.Slides pour C++, vous devez simplement utiliser les classes pertinentes et leurs méthodes / propriétés respectives pour effectuer des opérations qui semblent assez complexes si effectuées via des classes XML.

Voici quelques-unes des fonctionnalités qui ne sont même pas disponibles lors de la manipulation de documents PresentationML via des classes XML :

- Exporter des documents PPT vers des formats PDF, TIFF, XPS
- Exporter des diapositives dans les documents PPT vers des formats SVG
- Rendre une diapositive dans n'importe quel format d'image supporté par C++ Framework
- Copie automatique des maîtres à partir de présentations sources à l'aide de la fonction de clonage
- Appliquer une protection sur les formes

Prenons l'exemple d'un document PresentationML ayant une seule diapositive avec une zone de texte contenant le texte « Bonjour le monde ». Pour lire le texte via des classes XML, vous devrez écrire un programme capable de parser ce texte simple à partir du fragment suivant :

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

          <p:nvSpPr><p:cNvPr id="4" name="Texte 3"/>

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

                <a:rPr lang="fr-FR"/>

                <a:t>Bonjour le monde

                </a:t>

              </a:r>

              <a:endParaRPr lang="fr-FR"/>

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
## **Conversion PPT vers PPTX**
### **À propos de la conversion**
Aspose.Slides prend désormais également en charge la conversion de PPT à PPTX.
### **Fonctionnalités prises en charge dans la conversion**
Aspose.Slides pour C++ fournit un support partiel pour la conversion des présentations au format de fichier document PPT vers des présentations au format de fichier PPTX. Étant donné que le support de la fonctionnalité de conversion de présentation mentionnée vient d'être introduit dans Aspose.Slides pour C++, il a en ce moment une capacité limitée et ne fonctionne qu'avec les formulaires simples de présentations. L'avantage principal que la bibliothèque API Aspose.Slides pour C++ offre pour convertir une présentation PPT au format de présentation PPTX est la facilité d'utilisation de l'API pour atteindre l'objectif souhaité. Veuillez procéder à ce [lien]() pour la section sur les extraits de code pour plus de détails. La section suivante illustre clairement quelles fonctionnalités sont prises en charge et non prises en charge lors de la conversion de présentations au format PPT vers des présentations au format PPTX.
### **Fonctionnalités prises en charge**
Les fonctionnalités suivantes sont prises en charge lors de la conversion :

- Conversion de la structure des maîtres, des mises en page et des diapositives
- Conversion de la structure des maîtres, des mises en page et des diapositives
- Conversion des graphiques
- Groupes de formes
- Conversion des formes automatiques, y compris les rectangles et les ellipses. Cependant, il est possible que les formes automatiques aient des valeurs d'ajustement incorrectes
- Formes avec une géométrie personnalisée. Parfois, cela peut ne pas être converti
- Styles de remplissage de textures et d'images pour les formes automatiques. Parfois, cela peut ne pas être converti
- Conversion des espaces réservés
- Conversion du texte dans les cadres de texte et les supports de texte. Cependant, les puces, l'alignement et les tabulations ne sont pas entièrement implémentés
### **Fonctionnalités non prises en charge**
Les fonctionnalités suivantes ne sont pas prises en charge lors de la conversion :

- Diapositive avec des notes, car la lecture des notes n'est pas implémentée dans PPTX. Si PPT en a, alors il ne peut pas encore être enregistré en tant que PPTX
- Conversion des lignes et polylignes
- Formats de ligne et de remplissage
- Styles de remplissage en dégradé
- Cadres OLE, tableaux, vidéos et cadres audio, etc.
- L'animation et d'autres propriétés de diaporama sont ignorées

De nouvelles fonctionnalités ou manquantes seront ajoutées par la suite dans les prochaines versions d'Aspose.Slides pour C++.

Présentation PPT source

Présentation PPTX convertie
## **Format de document portable (PDF)**
### **À propos du PDF**
Le [Format de document portable](https://fr.wikipedia.org/wiki/PDF) est un format de fichier créé par Adobe System pour l'échange de documents entre différentes organisations. L'objectif de ce format était de permettre que le contenu des documents puisse être représenté de manière à ce que leur apparence visuelle ne dépende pas de la plateforme sur laquelle ils sont visualisés.
### **PDF dans Aspose.Slides pour C++**
Tout document de présentation pouvant être chargé dans Aspose.Slides pour C++ peut être converti en document PDF qui peut être conforme à [PDF 1.5](https://fr.wikipedia.org/wiki/PDF/A) ou [PDF /A-1b](https://fr.wikipedia.org/wiki/PDF/A) selon votre choix. Aspose.Slides pour C++ exporte les documents de présentation en PDF de telle sorte que la plupart du temps, le document PDF exporté ressemble presque au document de présentation original. La solution Aspose prend en charge les fonctionnalités suivantes des documents de présentation lors de la conversion en documents PDF :

- Images, zones de texte et autres formes
- Texte et formatage
- Paragraphes et formatage
- Hyperliens
- En-têtes et pieds de page
- Puces
- Tables

Vous pouvez exporter directement les documents de présentation vers des documents PDF en utilisant uniquement le composant Aspose.Slides pour C++. C'est-à-dire que vous n'avez pas besoin d'autre composant tiers ou composant Aspose.Pdf à cette fin. De plus, vous pouvez personnaliser l'exportation de la présentation vers PDF avec différentes options comme expliqué dans [ce sujet](/slides/cpp/converting-presentation-to-pdf/).

Un document de présentation converti en document PDF via Aspose.Slides pour C++
## **Spécification de l'analyseur XML (XPS)**
### **À propos de XPS**
La [Spécification de l'analyseur XML](https://fr.wikipedia.org/wiki/Open_XML_Paper_Specification) est un langage de description de page et un format de document fixe développé à l'origine par Microsoft. Comme PDF, XPS est un format de document à mise en page fixe conçu pour préserver la fidélité du document et fournir une apparence de document indépendante du dispositif.
### **XPS dans Aspose.Slides pour C++**
Tout document de présentation qui peut être chargé par Aspose.Slides pour C++ peut être converti en format XPS. Aspose.Slides pour C++ utilise le moteur de mise en page et de rendu haute fidélité pour produire des sorties au format de document XPS à mise en page fixe. Il convient de mentionner qu'Aspose.Slides pour C++ génère directement des XPS sans dépendre des classes Windows Presentation Foundation (WPF) qui sont emballées avec C++ Framework 3.5, permettant ainsi à Aspose.Slides pour C++ de produire des documents XPS sur des machines exécutant des versions de C++ Framework antérieures à la version 3.5. Vous pouvez en apprendre davantage sur l'exportation des documents de présentation vers des documents XPS via Aspose.Slides pour C++ dans [ce sujet](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/).

Un document de présentation converti en document XPS via Aspose.Slides pour C++