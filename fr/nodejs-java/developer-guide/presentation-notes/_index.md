---
title: Notes de présentation
type: docs
weight: 110
url: /fr/nodejs-java/presentation-notes/
keywords: "Notes du présentateur PowerPoint en JavaScript"
description: "Notes de présentation, notes du présentateur en JavaScript"
---

{{% alert color="primary" %}} 

Aspose.Slides prend en charge la suppression des diapositives de notes d'une présentation. Dans ce sujet, nous présenterons cette nouvelle fonctionnalité de suppression des notes ainsi que l'ajout de diapositives de style de notes à partir de n'importe quelle présentation. 

{{% /alert %}} 

Aspose.Slides for Node.js via Java offre la fonctionnalité de suppression des notes de n'importe quelle diapositive ainsi que d'ajouter un style aux notes existantes. Les développeurs peuvent supprimer les notes de la manière suivante :

* Supprimer les notes d'une diapositive spécifique d'une présentation.
* Supprimer les notes de toutes les diapositives d'une présentation


## **Supprimer les notes d'une diapositive**
Les notes d'une diapositive spécifique peuvent être supprimées comme le montre l'exemple ci-dessous :
```javascript
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
Les notes de toutes les diapositives d'une présentation peuvent être supprimées comme le montre l'exemple ci-dessous :
```javascript
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
La méthode [getNotesStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) a été ajoutée à la classe [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) respectivement. Cette propriété spécifie le style du texte des notes. L'implémentation est démontrée dans l'exemple ci-dessous.
```javascript
// Instancier un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Obtenir le style de texte du MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Définir un puce symbole pour les paragraphes du premier niveau
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Quelle entité API donne accès aux notes d'une diapositive spécifique ?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/) et une [méthode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) qui renvoie l'objet notes, ou `null` s'il n'y a pas de notes.

**Y a-t-il des différences de prise en charge des notes entre les versions de PowerPoint avec lesquelles la bibliothèque fonctionne ?**

La bibliothèque cible un large éventail de formats Microsoft PowerPoint (97-newer) ainsi que ODP ; les notes sont prises en charge dans ces formats sans dépendre d'une copie installée de PowerPoint.