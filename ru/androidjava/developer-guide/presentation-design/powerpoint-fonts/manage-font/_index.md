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
description: "Управляйте шрифтами в Java с помощью Aspose.Slides for Android: внедряйте, заменяйте и загружайте пользовательские шрифты, чтобы презентации PPT, PPTX и ODP оставались чистыми, соответствовали фирменному стилю и были согласованными."
---

## **Управление свойствами шрифтов**
{{% alert color="primary" %}} 

Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован по‑разному: либо для выделения определённых разделов и слов, либо в соответствии с корпоративными стилями. Форматирование текста помогает пользователям изменять внешний вид содержимого презентации. В этой статье показано, как с помощью Aspose.Slides for Android via Java настроить свойства шрифтов абзацев текста на слайдах.

{{% /alert %}} 

Чтобы управлять свойствами шрифта абзаца с помощью Aspose.Slides for Android via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите формы [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) на слайде и приведите их к типу [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. Получите [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) из [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/), предоставляемого [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. Выравнивайте абзац по ширине.
1. Доступ к [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) и его текстовой [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. Определите шрифт с помощью [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) и установите **Font** для текстовой [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
   1. Сделайте шрифт полужирным.
   1. Сделайте шрифт курсивным.
1. Установите цвет шрифта с помощью [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/), предоставляемого объектом [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. Сохраните изменённую презентацию в файл PPTX.

Ниже приведена реализация перечисленных шагов. Она берёт исходную презентацию без оформления и форматирует шрифты на одном из слайдов. Скриншоты ниже показывают исходный файл и то, как фрагменты кода изменяют его. Код меняет шрифт, цвет и стиль шрифта.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Рисунок: Текст в исходном файле**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Рисунок: Тот же текст с обновлённым форматированием**|
```java
	// Создайте объект Presentation, который представляет файл PPTX
	Presentation pres = new Presentation("FontProperties.pptx");
	try {
		// Доступ к слайду по его номеру
		ISlide slide = pres.getSlides().get_Item(0);

		// Получаем первый и второй placeholder на слайде и приводим их к типу AutoShape
		ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
		ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

		// Доступ к первому абзацу
		IParagraph para1 = tf1.getParagraphs().get_Item(0);
		IParagraph para2 = tf2.getParagraphs().get_Item(0);

		// Выравниваем абзац по ширине
		para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

		// Доступ к первой части текста (portion)
		IPortion port1 = para1.getPortions().get_Item(0);
		IPortion port2 = para2.getPortions().get_Item(0);

		// Определяем новые шрифты
		FontData fd1 = new FontData("Elephant");
		FontData fd2 = new FontData("Castellar");

		// Применяем новые шрифты к части текста
		port1.getPortionFormat().setLatinFont(fd1);
		port2.getPortionFormat().setLatinFont(fd2);

		// Делаем шрифт полужирным
		port1.getPortionFormat().setFontBold(NullableBool.True);
		port2.getPortionFormat().setFontBold(NullableBool.True);

		// Делаем шрифт курсивным
		port1.getPortionFormat().setFontItalic(NullableBool.True);
		port2.getPortionFormat().setFontItalic(NullableBool.True);

		// Устанавливаем цвет шрифта
		port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
		port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
		port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
		port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

		// Сохраняем PPTX на диск
		pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
	} finally {
		if (pres != null) pres.dispose();
	}
```


## **Установка свойств шрифта текста**
{{% alert color="primary" %}} 

Как упомянуто в разделе **Управление свойствами шрифтов**, объект [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) используется для хранения текста с одинаковым стилем форматирования в абзаце. В этой статье показано, как с помощью Aspose.Slides for Android via Java создать текстовое поле с некоторым текстом, а затем задать конкретный шрифт и различные другие свойства семейства шрифтов.

{{% /alert %}} 

Чтобы создать текстовое поле и задать свойства шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте на слайд [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) типа **Rectangle**.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. Получите [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) формы [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
1. Доступ к объекту [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/), связанному с [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. Установите другие свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства объекта [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. Запишите изменённую презентацию в файл PPTX.

Ниже приведена реализация перечисленных шагов.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с некоторыми свойствами шрифта, установленными Aspose.Slides for Android via Java**|
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
