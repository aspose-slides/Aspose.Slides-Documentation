---
title: Notes de présentation
type: docs
weight: 110
url: /androidjava/presentation-notes/
keywords: "Notes de conférencier PowerPoint en Java"
description: "Notes de présentation, notes de conférencier en Java"
---


{{% alert color="primary" %}} 

Aspose.Slides prend en charge la suppression des diapositives de notes d'une présentation. Dans ce sujet, nous allons introduire cette nouvelle fonctionnalité de suppression des notes ainsi que l'ajout de diapositives au style de notes à partir de n'importe quelle présentation. 

{{% /alert %}} 

Aspose.Slides pour Android via Java fournit la fonctionnalité de suppression des notes de n'importe quelle diapositive ainsi que d'ajouter du style aux notes existantes. Les développeurs peuvent supprimer des notes de la manière suivante :

* Supprimer les notes d'une diapositive spécifique d'une présentation.
* Supprimer les notes de toutes les diapositives d'une présentation.


## **Supprimer les notes d'une diapositive**
Les notes d'une diapositive spécifique peuvent être supprimées comme montré dans l'exemple ci-dessous :

```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Suppression des notes de la première diapositive
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Sauvegarder la présentation sur le disque
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer les notes de la présentation**
Les notes de toutes les diapositives d'une présentation peuvent être supprimées comme montré dans l'exemple ci-dessous :

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
    
    // Sauvegarder la présentation sur le disque
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter des NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) méthode a été ajoutée à [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) interface et [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) classe respectivement. Cette propriété spécifie le style d'un texte de notes. L'implémentation est démontrée dans l'exemple ci-dessous.

```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Obtenir le style de texte MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Définir le symbole de puce pour les paragraphes de premier niveau
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```