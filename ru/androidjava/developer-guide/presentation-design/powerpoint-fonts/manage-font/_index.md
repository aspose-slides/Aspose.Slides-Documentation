---
title: Управление шрифтами - PowerPoint Java API
linktitle: Управление шрифтами
type: docs
weight: 10
url: /androidjava/manage-fonts/
description: Презентации обычно содержат как текст, так и изображения. Эта статья показывает, как использовать PowerPoint Java API для настройки свойств шрифта абзацев текста на слайдах.
---

## **Управление свойствами, связанными со шрифтами**
{{% alert color="primary" %}} 

Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различным образом, чтобы выделить определенные разделы и слова или соответствовать корпоративным стилям. Форматирование текста помогает пользователям изменять внешний вид содержания презентации. Эта статья показывает, как использовать Aspose.Slides для Android через Java для настройки свойств шрифта абзацев текста на слайдах.

{{% /alert %}} 

Чтобы управлять свойствами шрифта абзаца с помощью Aspose.Slides для Android через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к фигурам [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Placeholder) на слайде и выполните преобразование их к [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. Получите [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph) из [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame), предоставленного [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. Выравняйте абзац.
1. Доступ к текстовому [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) абзаца [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph).
1. Определите шрифт с помощью [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FontData) и соответственно задайте **Font** текстового [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
   1. Установите шрифт как полужирный.
   1. Установите шрифт как курсивный.
1. Установите цвет шрифта, используя [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FillFormat), предоставленный объектом [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
1. Сохраните измененную презентацию в файл PPTX.

Реализация вышеуказанных шагов представлена ниже. Она принимает непримеренную презентацию и форматирует шрифты на одном из слайдов. Скриншоты, которые идут следом, показывают исходный файл и то, как фрагменты кода изменяют его. Код изменяет шрифт, цвет и стиль шрифта.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Рисунок: Текст в исходном файле**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Рисунок: Тот же текст с обновленным форматированием**|

```java
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Получить доступ к слайду по его позиции
	ISlide slide = pres.getSlides().get_Item(0);

	// Получить доступ к первому и второму заполнительным объектам на слайде и выполнить их преобразование в AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Получить доступ к первому абзацу
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Выравнивание абзаца
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Получить доступ к первой части
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Определить новые шрифты
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Присвоить новые шрифты части
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Установить шрифт в полужирный
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Установить шрифт в курсивный
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

## **Установить свойства шрифта текста**
{{% alert color="primary" %}} 

Как упоминалось в **Управлении свойствами шрифтов**, [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) используется для хранения текста с похожим стилем форматирования в абзаце. Эта статья показывает, как использовать Aspose.Slides для Android через Java для создания текстового поля с некоторым текстом, а затем определить определенный шрифт и различные другие свойства категории шрифтов.

{{% /alert %}} 

Чтобы создать текстовое поле и установить свойства шрифта текста в нем:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) типа **Rectangle** на слайд.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) объекта [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame).
1. Получите доступ к объекту [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion), связанному с [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame).
1. Определите шрифт для использования в [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
1. Установите другие свойства шрифта, такие как жирный, курсивный, подчеркивание, цвет и высота, используя соответствующие свойства, предоставленные объектом [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
1. Запишите измененную презентацию в файл PPTX.

Реализация вышеуказанных шагов представлена ниже.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с некоторыми свойствами шрифта, установленными Aspose.Slides для Android через Java**|

```java
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation();
try {
	// Получить первый слайд
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Добавить AutoShape типа Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Удалить любой стиль заливки, связанный с AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Получить доступ к TextFrame, связанному с AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Получить доступ к Portion, связанному с TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Установить шрифт для Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Установить свойство жирного шрифта
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Установить свойство курсивного шрифта
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Установить свойство подчеркивания шрифта
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