---
title: Gérer les notes de présentation sur Android
linktitle: Notes de présentation
type: docs
weight: 110
url: /fr/androidjava/presentation-notes/
keywords:
- notes
- diapositive de notes
- ajouter des notes
- supprimer des notes
- style de notes
- notes maître
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Personnalisez les notes de présentation avec Aspose.Slides pour Android via Java. Travaillez de manière fluide avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---

{{% alert color="primary" %}} 

Aspose.Slides prend en charge la suppression des diapositives de notes d'une presentation. Dans ce sujet, nous presenterons cette nouvelle fonctionnalite de suppression des notes ainsi que l'ajout de diapositives de style de notes a partir de n'importe quelle presentation. 

{{% /alert %}} 

Aspose.Slides for Android via Java offre la fonctionnalite de suppression des notes de n'importe quelle diapositive ainsi que l'ajout de style aux notes existantes. Les developpeurs peuvent supprimer les notes de la maniere suivante :

* Supprimer les notes d'une diapositive specifique d'une presentation.
* Supprimer les notes de toutes les diapositives d'une presentation


## **Supprimer les notes d'une diapositive**
Les notes d'une diapositive specifique peuvent etre supprimees comme le montre l'exemple ci-dessous:
```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Suppression des notes de la première diapositive
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Enregistrement de la présentation sur le disque
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Supprimer les notes d'une presentation**
Les notes de toutes les diapositives d'une presentation peuvent etre supprimees comme le montre l'exemple ci-dessous:
```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Suppression des notes de toutes les diapositives
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Enregistrement de la présentation sur le disque
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajouter un style de notes**
La methode [getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) a ete ajoutee à l'interface [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) respectivement. Cette propriete specifie le style du texte des notes. L'implementation est demontree dans l'exemple ci-dessous.
```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Obtenir le style de texte du MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Définir une puce symbole pour les paragraphes de premier niveau
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Quelle entite API fournit l'acces aux notes d'une diapositive specifique ?**

Les notes sont accesibles via le gestionnaire de notes de la diapositive : la diapositive possede un [NotesSlideManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/) et une [method](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) qui renvoie l'objet notes, ou `null` s'il n'y a aucune note.

**Existe-t-il des differences de prise en charge des notes selon les versions de PowerPoint avec lesquelles la bibliotheque fonctionne ?**

La bibliotheque cible une large gamme de formats Microsoft PowerPoint (97-et suivants) et ODP ; les notes sont prises en charge dans ces formats sans depender d'une copie installee de PowerPoint.