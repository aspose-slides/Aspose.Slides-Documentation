---
title: Сравнение презентаций слайдов на Android
linktitle: Сравнение слайдов
type: docs
weight: 50
url: /ru/androidjava/compare-slides/
keywords:
- сравнение слайдов
- сравнение презентаций
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Программно сравнивайте презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Android. Быстро определяйте различия слайдов в коде Java."
---

## **Сравнение двух слайдов**
Метод Equals был добавлен в интерфейс [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) и класс [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide). Он возвращает true для слайдов/макетов и мастер‑слайдов, которые идентичны по их структуре и статическому содержимому.  

Два слайда считаются равными, если все фигуры, стили, тексты, анимация и другие параметры и т.д. одинаковы. При сравнении не учитываются уникальные идентификаторы, например SlideId, и динамическое содержимое, например текущая дата в заполнителе даты.  
```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **Часто задаваемые вопросы**

**Влияет ли то, что слайд скрыт, на сравнение самих слайдов?**

[Hidden status](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) — это свойство уровня презентации/воспроизведения, а не визуального содержимого. Равенство двух конкретных слайдов определяется их структурой и статическим содержимым; сам факт, что слайд скрыт, не делает слайды разными.

**Учитываются ли гиперссылки и их параметры?**

Да. Ссылки являются частью статического содержимого слайда. Если URL или действие гиперссылки отличаются, это обычно считается различием в статическом содержимом.

**Если диаграмма ссылается на внешний файл Excel, будет ли содержимое этого файла учитываться?**

Нет. Сравнение выполняется на основе самих слайдов. Внешние источники данных обычно не читаются во время сравнения; учитывается только то, что присутствует в структуре и статическом состоянии слайда.