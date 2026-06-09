---
title: Not
type: docs
weight: 240
url: /tr/java/examples/elements/note/
keywords:
- kod örneği
- not
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java içinde slayt notlarıyla çalışın: PPT, PPTX ve ODP formatlarında konuşmacı notlarını ekleyin, okuyun, düzenleyin ve dışa aktarın, net Java örnekleri kullanarak."
---
Bu makale, **Aspose.Slides for Java** kullanarak not slaytlarını ekleme, okuma, kaldırma ve güncelleme işlemlerini göstermektedir.

## **Not Slaytı Ekle**

Bir not slaytı oluşturun ve ona metin atayın.

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **Not Slaytına Eriş**

Varolan bir not slaytından metni okuyun.

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **Not Slaytını Kaldır**

Bir slaytla ilişkili not slaytını kaldırın.

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **Not Metnini Güncelle**

Bir not slaytının metnini değiştirin.

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```