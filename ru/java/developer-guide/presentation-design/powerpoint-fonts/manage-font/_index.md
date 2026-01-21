---
title: Управление шрифтами в презентациях с помощью Java
linktitle: Управление шрифтами
type: docs
weight: 10
url: /ru/java/manage-fonts/
keywords:
- управление шрифтами
- свойства шрифта
- абзац
- форматирование текста
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте шрифтами в Java с помощью Aspose.Slides: внедряйте, заменяйте и загружайте пользовательские шрифты, чтобы презентации PPT, PPTX и ODP оставались чистыми, соответствовали бренду и были согласованными."
---

## **Управление свойствами шрифта**
{{% alert color="primary" %}} 

Презентации обычно содержат как текст, так и изображения. Текст можно форматировать различными способами, либо чтобы выделить определённые разделы и слова, либо чтобы соответствовать корпоративному стилю. Форматирование текста помогает пользователям разнообразить внешний вид содержимого презентации. В этой статье показано, как с помощью Aspose.Slides for Java настроить свойства шрифта абзацев текста на слайдах.

{{% /alert %}} 

Для управления свойствами шрифта абзаца с помощью Aspose.Slides for Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к фигурам типа [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) на слайде и приведение их к типу [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
1. Получите [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) из [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/), предоставляемого [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
1. Выравнивание абзаца по ширине.
1. Доступ к [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) текста абзаца.
1. Определите шрифт с помощью [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) и установите **Font** у текста [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) соответственно.
   1. Установите шрифт полужирным.
   1. Установите шрифт курсивом.
1. Установите цвет шрифта с помощью [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/), предоставляемого объектом [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/).
1. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеописанных шагов приведена ниже. Она берёт простую презентацию и форматирует шрифты на одном из слайдов. Скриншоты ниже показывают исходный файл и то, как кодовые фрагменты изменяют его. Код меняет шрифт, цвет и стиль шрифта.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Рисунок: Текст во входном файле**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Рисунок: Тот же текст с обновлённым форматированием**|
```java
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Доступ к слайду по его позиции
	ISlide slide = pres.getSlides().get_Item(0);

	// Доступ к первому и второму заполнителю на слайде и приведение к типу AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Доступ к первому абзацу
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Выравнивание абзаца по ширине
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Доступ к первой части
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Определить новые шрифты
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Присвоить новые шрифты части
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Установить шрифт жирным
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
{{% alert color="primary" %}} 

Как упоминается в **Управление свойствами шрифта**, [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) используется для хранения текста с одинаковым стилем форматирования в абзаце. Эта статья показывает, как с помощью Aspose.Slides for Java создать текстовое поле с некоторым текстом и затем определить конкретный шрифт и различные другие свойства семейства шрифтов.

{{% /alert %}} 

Для создания текстового поля и установки свойств шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте на слайд [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) типа **Rectangle**.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
1. Доступ к [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) у [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
1. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
1. Доступ к объекту [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/), связанному с [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/).
1. Установите другие свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства, предоставляемые объектом [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/).
1. Запишите изменённую презентацию в файл PPTX.

Реализация вышеописанных шагов приведена ниже.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с некоторыми установленными свойствами шрифта, заданными Aspose.Slides for Java**|
```java
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
	
	// Установить свойства Bold для шрифта
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Установить свойства Italic для шрифта
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Установить свойства Underline для шрифта
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
