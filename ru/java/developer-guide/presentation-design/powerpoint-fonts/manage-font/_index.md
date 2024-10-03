---
title: Управление Шрифтами - PowerPoint Java API
linktitle: Управление Шрифтами
type: docs
weight: 10
url: /ru/java/manage-fonts/
description: Презентации обычно содержат как текст, так и изображения. Эта статья показывает, как использовать PowerPoint Java API для настройки свойств шрифта абзацев текста на слайдах.
---

## **Управление Связанными со Шрифтом Свойствами**
{{% alert color="primary" %}} 

Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различным образом, чтобы выделить конкретные разделы и слова или соответствовать корпоративным стилям. Форматирование текста помогает пользователям варьировать внешний вид и восприятие содержания презентации. Эта статья показывает, как использовать Aspose.Slides для Java для настройки свойств шрифта абзацев текста на слайдах.

{{% /alert %}} 

Чтобы управлять свойствами шрифта абзаца с помощью Aspose.Slides для Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Placeholder) формам на слайде и выполните приведение к типу [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Получите [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph) из [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame), предоставленного [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Выравните абзац.
1. Получите текст [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph).
1. Определите шрифт с использованием [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FontData) и установите **Font** текстового [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) соответственно.
   1. Установите шрифт в жирный.
   1. Установите шрифт в курсив.
1. Установите цвет шрифта с использованием [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FillFormat), предоставленного объектом [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже. Она берёт неоформленную презентацию и форматирует шрифты на одном из слайдов. Скриншоты, которые идут следом, показывают входной файл и как фрагменты кода изменяют его. Код изменяет шрифт, цвет и стиль шрифта.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Рисунок: Текст во входном файле**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Рисунок: Тот же текст с обновлённым форматированием**|

```java
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Доступ к слайду по его позиции на слайде
	ISlide slide = pres.getSlides().get_Item(0);

	// Доступ к первому и второму заполнителю на слайде и приведение его к AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Доступ к первому абзацу
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Выравнивание абзаца
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Доступ к первому фрагменту
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Определить новые шрифты
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Присвоить новые шрифты фрагменту
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Установить шрифт в жирный
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Установить шрифт в курсив
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

## **Установка Свойств Шрифта Текста**
{{% alert color="primary" %}} 

Как упомянуто в **Управлении Связанными со Шрифтом Свойствами**, [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) используется для хранения текста с похожим стилем форматирования в абзаце. Эта статья показывает, как использовать Aspose.Slides для Java для создания текстового поля с некоторым текстом, а затем определить определённый шрифт и различные другие свойства шрифтовой категории.

{{% /alert %}} 

Чтобы создать текстовое поле и установить свойства шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape) типа **Прямоугольник** на слайд.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) связанного с [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. Получите доступ к объекту [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion), связанному с [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Установите другие свойства шрифта, такие как жирный, курсив, подчеркивание, цвет и высота, используя соответствующие свойства, предоставленные объектом [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Запишите изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с некоторыми свойствами шрифта, установленными Aspose.Slides для Java**|

```java
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation();
try {
	// Получить первый слайд
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Добавить AutoShape типа Прямоугольник
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Удалить любой стиль заливки, связанный с AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Получите доступ к TextFrame, связанному с AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Получите доступ к Portion, связанному с TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Установите шрифт для Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Установите жирный шрифт
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Установите курсивный шрифт
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Установите подчеркивание для шрифта
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Установите высоту шрифта
	port.getPortionFormat().setFontHeight(25);
	
	// Установите цвет шрифта
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Сохраните презентацию на диск
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```