---
title: Bölüm
type: docs
weight: 90
url: /tr/java/examples/elements/section/
keywords:
- kod örneği
- bölüm
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da slayt bölümlerini yönetin: Java örnekleriyle PPT, PPTX ve ODP için slaytları oluşturun, yeniden adlandırın, yeniden sıralayın ve gruplandırın."
---
Sunum bölümlerini yönetmek için örnekler—programlı olarak **Aspose.Slides for Java** kullanarak ekleme, erişme, kaldırma ve yeniden adlandırma.

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

## **Bölüm Erişimi**

Bir sunumdan bölüm bilgilerini okuyun.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // İndeks ile bir bölüme erişin.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Bölüm Silme**

Daha önce eklenmiş bir bölümü silin.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // İlk bölümü kaldırın.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Bölüm Yeniden Adlandırma**

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