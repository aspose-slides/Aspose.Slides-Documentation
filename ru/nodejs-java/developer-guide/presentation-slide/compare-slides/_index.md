---
title: Сравнение слайдов
type: docs
weight: 50
url: /ru/nodejs-java/compare-slides/
---

## **Сравнение двух слайдов**
Метод Equals был добавлен в класс [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) и в класс [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide). Он возвращает true для слайдов/макетов и слайдов-мастеров, которые идентичны по их структуре и статическому содержимому.

Два слайда считаются равными, если все фигуры, стили, тексты, анимация и другие параметры и т.д. одинаковы. При сравнении не учитываются значения уникальных идентификаторов, например SlideId, и динамическое содержимое, например текущее значение даты в заполнитель даты.
```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

Состояние скрытия является свойством уровня презентации/воспроизведения, а не визуального содержимого. Равенство двух конкретных слайдов определяется их структурой и статическим содержимым; сам факт скрытия слайда не делает слайды разными.

**Учитываются ли гиперссылки и их параметры?**

Да. Ссылки являются частью статического содержимого слайда. Если URL или действие гиперссылки отличаются, это обычно рассматривается как различие в статическом содержимом.

**Если диаграмма ссылается на внешний файл Excel, будет ли учитываться содержимое этого файла?**

Нет. Сравнение проводится на основе самих слайдов. Внешние источники данных обычно не читаются во время сравнения; учитывается только то, что присутствует в структуре и статическом состоянии слайда.