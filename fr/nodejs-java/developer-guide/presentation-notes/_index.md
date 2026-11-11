---
title: Gérer les notes de présentation en JavaScript
linktitle: Notes de présentation
type: docs
weight: 110
url: /fr/nodejs-java/presentation-notes/
keywords:
- notes
- diapositive de notes
- ajouter des notes
- supprimer des notes
- style de notes
- notes maîtres
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Personnalisez les notes de présentation en JavaScript avec Aspose.Slides pour Node.js. Travaillez sans effort avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---
## **Vue d'ensemble**

Aspose.Slides prend en charge la suppression des diapositives de notes d'une présentation. Dans cet article, nous présenterons cette fonctionnalité, y compris la façon de supprimer les notes et d'appliquer un style aux diapositives de notes d'une présentation. Aspose.Slides vous permet de supprimer les notes de n'importe quelle diapositive et également d'appliquer un style aux notes existantes. Les développeurs peuvent supprimer les notes de la manière suivante :

- Supprimer les notes d'une diapositive spécifique d'une présentation.
- Supprimer les notes de toutes les diapositives d'une présentation.

Pour lire ou modifier les dimensions de la page de notes, changer l'orientation et vérifier le comportement d'exportation, voir [Taille de la page de notes](/slides/fr/nodejs-java/notes-size/).

## **Supprimer les notes d'une diapositive**
Les notes d'une diapositive spécifique peuvent être supprimées comme indiqué dans l'exemple ci-dessous:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Suppression des notes de la première diapositive
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Enregistrement de la présentation sur le disque
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Supprimer les notes d'une présentation**
Les notes de toutes les diapositives d'une présentation peuvent être supprimées comme indiqué dans l'exemple ci-dessous:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Suppression des notes de toutes les diapositives
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Enregistrement de la présentation sur le disque
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ajouter NotesStyle**
La méthode [getNotesStyle](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) a été ajoutée à la classe [MasterNotesSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/MasterNotesSlide) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/MasterNotesSlide) respectivement. Cette propriété spécifie le style d'un texte de notes. L'implémentation est présentée dans l'exemple ci-dessous.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Obtenir le style de texte du MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Définir une puce symbole pour les paragraphes du premier niveau
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quel élément d'API fournit l'accès aux notes d'une diapositive spécifique ?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notesslidemanager/) et une [méthode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) qui renvoie l'objet notes, ou `null` s'il n'y a pas de notes.

**Existe-t-il des différences de prise en charge des notes selon les versions de PowerPoint avec lesquelles la bibliothèque fonctionne ?**

La bibliothèque cible une large gamme de formats Microsoft PowerPoint (97-et plus) et ODP; les notes sont prises en charge dans ces formats sans dépendre d'une copie installée de PowerPoint.