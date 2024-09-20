---
title: Преобразование слайда
type: docs
weight: 35
url: /androidjava/convert-slide/
keywords: "Преобразовать слайд в изображение, экспортировать слайд как изображение, сохранить слайд как изображение, слайд в изображение, слайд в PNG, слайд в JPEG, слайд в битмап, Java, java, Aspose.Slides"
description: "Преобразование слайда PowerPoint в изображение (битмап, PNG или JPG) на Java"
---

Aspose.Slides для Android через Java позволяет вам преобразовывать слайды (в презентациях) в изображения. Вот поддерживаемые форматы изображений: BMP, PNG, JPG (JPEG), GIF и другие.

Чтобы преобразовать слайд в изображение, выполните следующие шаги:

1. Во-первых,
   * преобразуйте слайд в изображения, используя метод [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) или

2. Во-вторых, установите дополнительные параметры для преобразования и преобразуемые объекты слайдов через
   * интерфейс [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions) или
   * интерфейс [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions).

## **О битмапах и других форматах изображений**

В Java объект [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images) позволяет работать с изображениями, определяемыми пиксельными данными. Вы можете использовать экземпляр этого класса для сохранения изображений в широком диапазоне форматов (JPG, PNG и т. д.).

{{% alert title="Информация" color="info" %}}

Aspose недавно разработал онлайн конвертер [Текст в GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Преобразование слайдов в битмап и сохранение изображений в PNG**

Этот код на Java показывает, как преобразовать первый слайд презентации в объект битмап, а затем как сохранить изображение в формате PNG:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Преобразует первый слайд в объект Images
    IImage slideImage = pres.getSlides().get_Item(0).getImage();

	// Сохраняет изображение в формате PNG
	try {
        // сохраняет изображение на диске.
         slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Этот пример кода показывает вам, как преобразовать первый слайд презентации в объект битмап, используя метод [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-):

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// Получает размеры слайда презентации
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// Создает изображение с размерами слайда
    IImage slideImage = sld.getImage(new RenderingOptions(), slideSize);
    try {
         // сохраняет изображение на диске.
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Совет" color="primary" %}} 

Вы можете преобразовать слайд в объект Images, а затем использовать этот объект непосредственно где-либо. Или вы можете преобразовать слайд в Images, а затем сохранить изображение в JPEG или любом другом формате, который вам нравится.

{{% /alert %}}  

## **Преобразование слайдов в изображения с пользовательскими размерами**

Вам может понадобиться получить изображение определенного размера. Используя перегрузку метода [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) вы можете преобразовать слайд в изображение с конкретными размерами (длиной и шириной).

Этот пример кода демонстрирует предложенное преобразование с использованием метода [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) в Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Преобразует первый слайд презентации в битмап с указанным размером
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1820, 1040));
	
	// Сохраняет изображение в формате JPEG
	try {
         // сохраняет изображение на диске.
          slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Преобразование слайдов с заметками и комментариями в изображения**

Некоторые слайды содержат заметки и комментарии.

Aspose.Slides предоставляет два интерфейса — [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions) и [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions) — которые позволяют контролировать рендеринг слайдов презентации в изображения. Оба интерфейса содержат интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions), который позволяет добавлять заметки и комментарии на слайд при его преобразовании в изображение.

{{% alert title="Информация" color="info" %}} 

С помощью интерфейса [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) вы можете указать предпочитаемое положение для заметок и комментариев на результирующем изображении.

{{% /alert %}} 

Этот код на Java демонстрирует процесс преобразования слайда с заметками и комментариями:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // Создает параметры рендеринга
    IRenderingOptions options = new RenderingOptions();

    // Устанавливает положение заметок на странице
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // Устанавливает положение комментариев на странице 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // Устанавливает ширину области вывода комментариев
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // Устанавливает цвет области комментариев
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // Преобразует первый слайд презентации в объект битмап
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, 2f, 2f);

    // Сохраняет изображение в формате GIF
    try {
          slideImage.save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Этот код на Java демонстрирует процесс преобразования слайда с заметками, используя метод [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-):

``` java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// Получает размер заметок презентации
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// Создает параметры рендеринга
	IRenderingOptions options = new RenderingOptions();

	// Устанавливает положение заметок
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Создает изображение с размерами заметок
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, notesSize);

	// Сохраняет изображение в формате PNG
    try {
         // сохраняет изображение на диске.
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Примечание" color="warning" %}} 

В любом процессе преобразования слайда в изображение свойство [NotesPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) не может быть установлено на BottomFull (для указания положения заметок), поскольку текст заметки может быть большим, и он может не поместиться в указанном размере изображения.

{{% /alert %}} 

## **Преобразование слайдов в изображения с использованием ITiffOptions**

Интерфейс [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions) дает вам больше контроля (в терминах параметров) над результирующим изображением. С помощью этого интерфейса вы можете задать размер, разрешение, цветовую палитру и другие параметры для результирующего изображения.

Этот код на Java демонстрирует процесс преобразования, в котором используются ITiffOptions для вывода черно-белого изображения с разрешением 300dpi и размером 2160 × 2800:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// Получает слайд по индексу
	ISlide slide = pres.getSlides().get_Item(0);

	// Создает объект TiffOptions
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// Устанавливает шрифт, используемый в случае, если исходный шрифт не найден
	options.setDefaultRegularFont("Arial Black");

	// Устанавливает положение заметок на странице
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Устанавливает формат пикселей (черно-белый)
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// Устанавливает разрешение
	options.setDpiX(300);
	options.setDpiY(300);

	// Преобразует слайд в объект битмап
	IImage slideImage = slide.getImage(options);

	// Сохраняет изображение в формате TIFF
	try {
          slideImage.save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Примечание" color="warning" %}} 

Поддержка Tiff не гарантируется в версиях ниже JDK 9.

{{% /alert %}} 

## **Преобразование всех слайдов в изображения**

Aspose.Slides позволяет вам преобразовать все слайды в одной презентации в изображения. По сути, вы можете преобразовать презентацию (в целом) в изображения.

Этот пример кода показывает, как преобразовать все слайды в презентации в изображения на Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Рендеринг презентации в массив изображений слайд за слайдом
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // Контроль скрытых слайдов (не рендерить скрытые слайды)
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // Преобразует слайд в объект битмап
        IImage slideImage = pres.getSlides().get_Item(i).getImage(2f, 2f);

        // Сохраняет изображение в формате PNG
        try {
              slideImage.save("Slide_" + i + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
} 
```