---
title: Différents formats de fichiers et conversions
type: docs
weight: 50
url: /fr/cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **À propos de PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) est le format de fichier de documents de présentation qui peut être créé, lu, manipulé et écrit par différentes versions de Microsoft PowerPoint. Il s'agit du format binaire pour les documents de présentation développé par Microsoft.
### **PPT dans Aspose.Slides pour C++**
Aspose.Slides pour C++ peut lire les fichiers PPT créés par les logiciels répertoriés ci-dessous.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

De même, les fichiers PPT créés par Aspose.Slides pour C++ peuvent être lus par l'ensemble de logiciels ci‑dessus.
### **Prise en charge complète de PPT**
Aspose.Slides pour C++ offre une prise en charge de presque toutes les fonctionnalités liées au format de fichier de document PPT. Il couvre non seulement les fonctionnalités de base et avancées fournies par les différentes versions de Microsoft PowerPoint pour la manipulation des documents PPT, mais également certaines fonctionnalités qui ne sont même pas prises en charge par Microsoft PowerPoint. Le principal avantage d’utiliser la bibliothèque d’API Aspose.Slides pour C++ est la facilité d’utilisation pour gérer ces fonctionnalités.

En plus des tâches de base liées à la création, la lecture et l’écriture de fichiers de documents PPT, plusieurs fonctionnalités sont fournies par Aspose.Slides pour C++ telles que :

- Importer d’autres formats de fichiers MS Office en tant qu’objets OLE dans les documents PPT.
- Exporter des documents PPT vers les formats PDF, TIFF, XPS.
- Exporter les diapositives des documents PPT vers les formats SVG.
- Rendre une diapositive dans n’importe quel format d’image pris en charge par le Framework C++.
- Définir la taille des diapositives dans le document PPT.
- Gérer les animations sur les formes.
- Gérer les diaporamas.
- Formater le texte sur les diapositives.
- Analyser le texte des documents PPT.
- Manipuler les tableaux sur les diapositives.
- Copie automatique des maîtres à l’aide de la fonction de clonage.

Un fichier PPT généré par Aspose.Slides pour C++ et ouvert dans Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **À propos de PresentationML**
PresentationML désigne une famille de formats basés sur XML pour les documents de présentation. Office OpenXML (OOXML) est le format basé sur XML introduit dans les applications Microsoft Office 2007. Office OpenXML est un format conteneur pour plusieurs langages de balisage spécialisés basés sur XML. PresentationML est le langage de balisage utilisé par Microsoft Office PowerPoint 2007 pour stocker ses documents.
### **PresentationML dans Aspose.Slides pour C++**
Les documents OOXML PresentationML se présentent sous forme de fichiers PPTX, qui sont des packages XML compressés suivant les spécifications [OOXML ECMA‑376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides pour C++ prend en charge de façon exhaustive la création, la lecture, la manipulation et l’écriture de documents PresentationML. De plus, Aspose.Slides pour C++ peut exporter les documents PresentationML vers différents formats largement utilisés comme PDF, TIFF et XPS. Cela est possible parce qu’Aspose.Slides pour C++ a été conçu pour gérer de façon complète les documents de présentation, et PresentationML stocke essentiellement la présentation interne des documents sous forme de package XML compressé.

Un document PPTX généré par Aspose.Slides pour C++ et ouvert dans Microsoft PowerPoint

Visualisation d’un document PPTX généré par Aspose.Slides pour C++ dans une application Zip
### **PresentationML est ouvert, pourquoi utiliser Aspose.Slides pour C++**
Étant donné que PresentationML est basé sur XML, il est tout à fait possible de créer des applications de traitement et de génération de documents PresentationML en utilisant des classes XML sans dépendre de bibliothèques tierces telles qu’Aspose.Slides pour C++. Cependant, plusieurs avantages existent à utiliser Aspose.Slides pour C++ plutôt que des classes XML lors du travail avec des documents PresentationML.

La spécification OOXML s’étend sur plusieurs milliers de pages. Cela signifie que, pour gérer correctement les documents PresentationML, vous devez consacrer beaucoup de temps et d’efforts à comprendre le format de ces documents. En revanche, avec Aspose.Slides pour C++, il vous suffit d’utiliser les classes pertinentes et leurs méthodes / propriétés respectives pour effectuer des opérations qui sembleraient très complexes via les classes XML.

Voici quelques‑unes des fonctionnalités qui ne sont même pas disponibles lorsqu’on travaille avec des documents PresentationML via des classes XML :

- Exporter des documents PPT vers les formats PDF, TIFF, XPS
- Exporter les diapositives des documents PPT vers les formats SVG
- Rendre une diapositive dans n’importe quel format d’image pris en charge par le Framework C++
- Copie automatique des maîtres des présentations sources à l’aide de la fonction de clonage
- Appliquer une protection aux formes

Prenons l’exemple d’un document PresentationML contenant une seule diapositive avec une zone de texte contenant le texte « Hello World ». Pour lire le texte via les classes XML, vous devrez écrire un programme capable d’analyser ce texte simple à partir du fragment suivant :
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

## **Conversion PPT vers PPTX**
### **À propos de la conversion**
Aspose.Slides prend désormais également en charge la conversion de PPT vers PPTX.
### **Fonctionnalités prises en charge dans la conversion**
Aspose.Slides pour C++ fournit une prise en charge partielle de la conversion des présentations au format de fichier PPT vers le format de fichier PPTX. Comme la prise en charge de cette fonction de conversion de présentations vient d’être introduite dans Aspose.Slides pour C++, elle possède actuellement des capacités limitées et ne fonctionne que pour les formes simples de présentations. Le principal avantage offert par la bibliothèque d’API Aspose.Slides pour C++ pour convertir une présentation PPT au format PPTX est la facilité d’utilisation de l’API afin d’atteindre l’objectif souhaité. Veuillez vous rendre à this[link]() pour la section des extraits de code pour plus de détails. La section suivante illustre clairement quelles fonctionnalités sont prises en charge et lesquelles ne le sont pas lors de la conversion de présentations au format PPT vers le format PPTX.
### **Fonctionnalités prises en charge**
Les fonctionnalités suivantes sont prises en charge lors de la conversion :

- Conversion de la structure des maîtres, des mises en page et des diapositives
- Conversion de la structure des maîtres, des mises en page et des diapositives
- Conversion des graphiques
- Formes groupées
- Conversion des Auto‑shapes incluant les rectangles et les ellipses. Cependant, il est possible que les Auto‑shapes aient des valeurs d’ajustement incorrectes
- Formes avec géométrie personnalisée. Parfois non converties
- Styles de remplissage Textures et Images pour les Auto‑shapes. Parfois non converties
- Conversion des espaces réservés
- Conversion du texte dans les zones de texte et les porteurs de texte. Cependant, les puces, l’alignement et les tabulations ne sont pas entièrement implémentés
### **Fonctionnalités non prises en charge**
Les fonctionnalités suivantes ne sont pas prises en charge lors de la conversion :

- Diapositive avec notes, la lecture des notes n’étant pas implémentée dans PPTX. Si le PPT en possède, il ne peut pas encore être enregistré en PPTX* Conversion des lignes et polylignes
- Formats de ligne et de remplissage
- Styles de remplissage en dégradé
- Cadres OLE, tableaux, vidéos et cadres audio, etc.
- Les animations et autres propriétés de diaporama sont ignorées
  De nouvelles fonctionnalités ou des fonctionnalités manquantes seront ajoutées ultérieurement dans les futures versions d’Aspose.Slides pour C++.

Présentation PPT source

Présentation PPTX convertie
## **Portable Document Format (PDF)**
### **À propos de PDF**
Le [Portable Document Format](https://en.wikipedia.org/wiki/PDF) est un format de fichier créé par Adobe System pour l’échange de documents entre différentes organisations. L’objectif de ce format était de permettre que le contenu des documents puisse être représenté de façon à ce que leur apparence visuelle ne dépende pas de la plateforme sur laquelle ils sont consultés.
### **PDF dans Aspose.Slides pour C++**
Tout document de présentation qui peut être chargé dans Aspose.Slides pour C++ peut être converti en document PDF conforme à [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) ou à [PDF /A‑1b](https://en.wikipedia.org/wiki/PDF/A), selon votre choix. Aspose.Slides pour C++ exporte les documents de présentation vers PDF de telle manière que, la plupart du temps, le PDF exporté ressemble presque à l’original. La solution Aspose prend en charge les fonctionnalités suivantes des documents de présentation lors de la conversion en documents PDF :

- Images, zones de texte et autres formes
- Texte et mise en forme
- Paragraphes et mise en forme
- Hyperliens
- En‑têtes et pieds de page
- Puces
- Tableaux

Vous pouvez exporter directement les documents de présentation vers PDF en utilisant uniquement le composant Aspose.Slides pour C++. Vous n’avez donc besoin d’aucun autre tier ou du composant Aspose.Pdf à cet effet. De plus, vous pouvez personnaliser l’exportation de la présentation vers PDF avec différentes options comme expliqué dans [this topic](/slides/fr/cpp/convert-powerpoint-to-pdf/).

Un document de présentation converti en document PDF via Aspose.Slides pour C++
## **XML Parser Specification (XPS)**
### **À propos de XPS**
La [XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) est un langage de description de page et un format de document fixe initialement développé par Microsoft. À l’instar du PDF, XPS est un format de document à mise en page fixe conçu pour préserver la fidélité du document et fournir une apparence indépendante du dispositif.
### **XPS dans Aspose.Slides pour C++**
Tout document de présentation qui peut être chargé par Aspose.Slides pour C++ peut être converti au format XPS. Aspose.Slides pour C++ utilise le moteur de mise en page et de rendu haute fidélité pour produire une sortie au format de document XPS à mise en page fixe. Il convient de mentionner qu’Aspose.Slides pour C++ génère directement le XPS sans dépendre des classes Windows Presentation Foundation (WPF) empaquetées avec le Framework C++ 3.5, ce qui permet à Aspose.Slides pour C++ de produire des documents XPS sur des machines exécutant des versions du Framework C++ antérieures à la version 3.5. Vous pouvez en savoir plus sur l’exportation des documents de présentation vers des documents XPS via Aspose.Slides pour C++ dans [this topic](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/).

Un document de présentation converti en document XPS via Aspose.Slides pour C++