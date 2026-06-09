---
title: Bölüm
type: docs
weight: 90
url: /tr/androidjava/examples/elements/section/
keywords:
- kod örneği
- bölüm
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de slayt bölümlerini yönetin: PPT, PPTX ve ODP için Java örnekleriyle slaytları oluşturun, yeniden adlandırın, yeniden sıralayın ve gruplandırın."
---
Sunum bölümlerini yönetmek için örnekler—programatik olarak ekleme, erişme, silme ve yeniden adlandırma işlemleri **Aspose.Slides for Android via Java** kullanılarak.

## **Bölüm Ekle**

Belirli bir slaytta başlayan bir bölüm oluşturun.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Bölümün başlangıcını işaret eden slaytı belirtin.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Bir Bölüme Eriş**

Bir sunumdan bölüm bilgilerini okuyun.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // İndeksle bir bölüme eriş.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Bölümü Kaldır**

Daha önce eklenmiş bir bölümü silin.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // İlk bölümü kaldır.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Bölümü Yeniden Adlandır**

Mevcut bir bölümün adını değiştirin.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```