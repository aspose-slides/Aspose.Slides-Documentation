---
title: Изменение размера фигур на слайдах презентации
type: docs
weight: 110
url: /ru/java/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Легко изменяйте размер фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Java - автоматизируйте настройку макета слайдов и повышайте производительность."
---
## **Обзор**

Один из самых часто задаваемых вопросов клиентами Aspose.Slides for Java — как изменить размер фигур так, чтобы при изменении размера слайда данные не обрезались. Эта короткая техническая статья покажет, как это сделать.

## **Изменение размера фигур**

Чтобы фигуры не смещались при изменении размера слайда, обновите позицию и размеры каждой фигуры так, чтобы они соответствовали новому макету слайда.

```java
import com.aspose.slides.*;

// Загрузить файл презентации.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Получить исходный размер слайда.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Изменить размер слайда без масштабирования существующих фигур.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Получить новый размер слайда.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Изменить размер и переместить фигуры на каждом слайде.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Масштабировать размер фигуры.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Масштабировать позицию фигуры.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 

Таблицы не требуют специальной обработки: установка ширины и высоты таблицы масштабирует её столбцы и строки пропорционально, поэтому повторное масштабирование высот строк и ширины столбцов применит коэффициент дважды. 

{{% /alert %}} 

Приведённый выше код изменяет только фигуры на слайдах. Слайды‑мастера и слайды‑макеты имеют свои собственные фигуры, поэтому масштабируйте их тоже, если хотите, чтобы вся презентация соответствовала новому размеру слайда:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Получить исходный размер слайда.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Изменить размер слайда без масштабирования существующих фигур.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Получить новый размер слайда.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Масштабировать размер фигуры.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Масштабировать позицию фигуры.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Масштабировать размер фигуры.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Масштабировать позицию фигуры.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Масштабировать размер фигуры.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Масштабировать позицию фигуры.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

### Почему фигуры искажаются или обрезаются после изменения размера слайда?

При изменении размера слайда фигуры сохраняют своё исходное положение и размер, если явно не изменить масштаб. Это может привести к обрезке содержимого или смещению фигур.

### Работает ли предоставленный код для всех типов фигур?

Да. Установка высоты и ширины работает для текстовых полей, изображений, диаграмм и таблиц одинаково.

### Как изменить размер таблиц при изменении размера слайда?

Масштабируйте саму фигуру таблицы, точно так же, как любую другую фигуру. Её строки и столбцы масштабируются пропорционально, поэтому не масштабируйте их повторно позже.

### Будет ли это работать для слайдов‑мастеров и слайдов‑макетов?

Да, но вам также следует пройтись по [Masters](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getMasters--) и [Layout slides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getLayoutSlides--) и применить ту же логику масштабирования к их фигурам, чтобы обеспечить согласованность во всей презентации.

### Можно ли изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?

Да. Вы можете использовать [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidesize/#setOrientation-int-) для изменения ориентации. Убедитесь, что логика масштабирования настроена соответствующим образом, чтобы сохранить макет.

### Есть ли ограничение на размер слайда, который я могу задать?

Aspose.Slides поддерживает пользовательские размеры, но очень большие размеры могут влиять на производительность или совместимость с некоторыми версиями PowerPoint.

### Как предотвратить искажение фигур с фиксированным соотношением сторон?

Перед масштабированием проверьте метод `getAspectRatioLocked` у фигуры. Если он заблокирован, изменяйте ширину или высоту пропорционально, а не масштабируйте их по отдельности.