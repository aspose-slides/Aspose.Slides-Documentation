---
title: Управление шрифтами в презентациях на Android
linktitle: Управление шрифтами
type: docs
weight: 10
url: /ru/androidjava/manage-fonts/
keywords:
  - управление шрифтами
  - свойства шрифтов
  - абзац
  - форматирование текста
  - PowerPoint
  - OpenDocument
  - презентация
  - Android
  - Java
  - Aspose.Slides
description: "Управляйте шрифтами в Java с помощью Aspose.Slides для Android: внедряйте, заменяйте и загружайте пользовательские шрифты, чтобы презентации PPT, PPTX и ODP оставались понятными, соответствующими бренду и согласованными."
---
## **Обзор**

Aspose.Slides позволяет управлять свойствами шрифтов в тексте презентации непосредственно из вашего кода. Вы можете получать доступ к тексту на слайдах через фигуры, текстовые фреймы, абзацы и части, а затем применять форматирование к выбранному тексту.

В этой статье объясняется, как настроить свойства шрифта для существующего текста в презентации, включая семейство шрифта, полужирный и курсивный стили, выравнивание абзаца и цвет шрифта. Также показывается, как создать текстовое поле, добавить в него текст и задать свойства шрифта, такие как семейство шрифта, полужирный, курсив, подчёркивание, размер и цвет, перед сохранением результата в файл PPTX.

## **Управление свойствами шрифта**
{{% alert color="info" %}} 

Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различными способами, чтобы выделить определённые разделы и слова или соответствовать корпоративным стилям. Форматирование текста помогает пользователям разнообразить внешний вид содержимого презентации. В этой статье показано, как с помощью Aspose.Slides for Android via Java настроить свойства шрифта абзацев текста на слайдах.

{{% /alert %}} 

Для управления свойствами шрифта абзаца с помощью Aspose.Slides for Android via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к фигурам [Placeholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholder/) на слайде и приведение их к типу [AutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/autoshape/).
1. Получите [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/) из [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframe/), предоставляемого [AutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/autoshape/).
1. Выравнивайте абзац по ширине.
1. Доступ к части текста [Portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portion/) абзаца.
1. Определите шрифт с помощью [FontData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontdata/) и установите **Font** для части текста [Portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portion/).
   1. Установите шрифт полужирным.
   1. Установите шрифт курсивом.
1. Задайте цвет шрифта с помощью [FillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/), предоставляемого объектом [Portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portion/).
1. Сохраните изменённую презентацию в файл PPTX.

Реализация описанных шагов приведена ниже. Она берёт простую презентацию и формирует шрифты на одном из слайдов. Снимки экрана ниже показывают исходный файл и то, как фрагменты кода изменяют его. Код меняет шрифт, цвет и стиль шрифта.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Рисунок: Текст во входном файле**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Рисунок: Тот же текст с обновлённым форматированием**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Получение слайда по его позиции
	ISlide slide = pres.getSlides().get_Item(0);

	// Получение первого и второго заполняющего элемента (placeholder) на слайде и приведение его к типу AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Получение первого абзаца
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Выровнять абзац по ширине
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Получение первой части текста
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Определение новых шрифтов
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Назначение новых шрифтов части текста
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Установить шрифт полужирным
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Установить шрифт курсивом
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Установить цвет шрифта
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Сохранить PPTX на диск
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Установка свойств шрифта текста**
{{% alert color="info" %}} 

Как упомянуто в разделе **Управление свойствами шрифта**, [Portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portion/) используется для удержания текста с одинаковым стилем форматирования в абзаце. Эта статья показывает, как с помощью Aspose.Slides for Android via Java создать текстовое поле с некоторым текстом и затем определить конкретный шрифт и различные другие свойства категории семейства шрифтов.

{{% /alert %}} 

Для создания текстового поля и установки свойств шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте к слайду [AutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/autoshape/) типа **Rectangle**.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/autoshape/).
1. Доступ к [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframe/) фигуры [AutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/autoshape/).
1. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframe/).
1. Доступ к объекту [Portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portion/), связанному с [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframe/).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portion/).
1. Установите другие свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства, предоставляемые объектом [Portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portion/).
1. Запишите изменённую презентацию в файл PPTX.

Реализация описанных шагов приведена ниже.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с некоторыми свойствами шрифта, установленными Aspose.Slides for Android via Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation();
try {
	// Получить первый слайд
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Добавить AutoShape типа Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Удалить любой стиль заливки, связанный с AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Получить TextFrame, связанный с AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Получить Portion, связанный с TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Установить шрифт для Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Установить свойство Bold у шрифта
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Установить свойство Italic у шрифта
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Установить свойство Underline у шрифта
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Установить высоту шрифта
	port.getPortionFormat().setFontHeight(25);
	
	// Установить цвет шрифта
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Сохранить презентацию на диск
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```