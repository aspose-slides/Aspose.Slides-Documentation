---
title: Gérer les notes de présentation en Java
linktitle: Notes de présentation
type: docs
weight: 110
url: /fr/java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Personnalisez les notes de présentation avec Aspose.Slides pour Java. Travaillez sans effort avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---
## **Vue d'ensemble**

Aspose.Slides prend en charge la suppression des diapositives de notes d’une présentation. Dans cet article, nous présenterons cette fonctionnalité, y compris la façon de supprimer les notes et d’appliquer un style aux diapositives de notes dans une présentation. Aspose.Slides vous permet de supprimer les notes de n’importe quelle diapositive et également d’appliquer un style aux notes existantes. Les développeurs peuvent supprimer les notes de les manières suivantes :
- Supprimer les notes d’une diapositive spécifique dans une présentation.
- Supprimer les notes de toutes les diapositives d’une présentation.

Pour lire ou modifier les dimensions de la page de notes, changer l’orientation et vérifier le comportement d’exportation, consultez [Taille de la page de notes](/slides/fr/java/notes-size/).

## **Supprimer les notes d’une diapositive**
Les notes d’une diapositive spécifique peuvent être supprimées comme indiqué dans l’exemple ci‑dessous :

```java
import com.aspose.slides.*;

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

## **Supprimer les notes d’une présentation**
Les notes de toutes les diapositives d’une présentation peuvent être supprimées comme indiqué dans l’exemple ci‑dessous :

```java
import com.aspose.slides.*;

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
La méthode [getNotesStyle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) a été ajoutée à l’interface [IMasterNotesSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IMasterNotesSlide) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/MasterNotesSlide) respectivement. Cette propriété spécifie le style du texte des notes. L’implémentation est illustrée dans l’exemple ci‑dessous.

```java
import com.aspose.slides.*;

// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Obtenir le style de texte du MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Définir le puce symbolique pour les paragraphes du premier niveau
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quelle entité de l’API fournit l’accès aux notes d’une diapositive spécifique ?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notesslidemanager/) et une [méthode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) qui renvoie l’objet notes, ou `null` s’il n’y a pas de notes.

**Existe-t-il des différences dans la prise en charge des notes selon les versions de PowerPoint avec lesquelles la bibliothèque fonctionne ?**

La bibliothèque cible une large gamme de formats Microsoft PowerPoint (97–newer) ainsi que le format ODP ; les notes sont prises en charge dans ces formats sans dépendre d’une copie installée de PowerPoint.