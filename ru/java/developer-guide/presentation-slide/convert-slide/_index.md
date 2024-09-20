---
title: Конвертировать слайд
type: docs
weight: 35
url: /java/convert-slide/
keywords: "Конвертировать слайд в изображение, экспортировать слайд как изображение, сохранить слайд как изображение, слайд в изображение, слайд в PNG, слайд в JPEG, слайд в Bitmap, Java, java, Aspose.Slides"
description: "Конвертировать слайд PowerPoint в изображение (Bitmap, PNG или JPG) на Java"
---

Aspose.Slides для Java позволяет вам конвертировать слайды (в презентациях) в изображения. Поддерживаемые форматы изображений: BMP, PNG, JPG (JPEG), GIF и другие.

Чтобы конвертировать слайд в изображение, выполните следующие действия:

1. Во-первых,
   * конвертируйте слайд в объекты изображений, используя метод [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) или

2. Во-вторых, установите дополнительные параметры для конвертации и конвертируемых объектов слайдов через
   * интерфейс [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) или
   * интерфейс [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions).

## **О Bitmap и других форматах изображений**

В Java [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images) — это объект, который позволяет вам работать с изображениями, определенными с помощью пиксельных данных. Вы можете использовать экземпляр этого класса для сохранения изображений в широком диапазоне форматов (JPG, PNG и т. д.).

{{% alert title="Информация" color="info" %}}

Aspose недавно разработал онлайн-конвертер [Текст в GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Конвертация слайдов в Bitmap и сохранение изображений в PNG**

Этот код на Java демонстрирует, как конвертировать первый слайд презентации в объект bitmap, а затем как сохранить изображение в формате PNG:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Конвертирует первый слайд презентации в объект Images
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

Этот образец кода демонстрирует, как конвертировать первый слайд презентации в объект bitmap, используя метод [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-):

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// Получает размер слайда презентации
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// Создает Images с размером слайда
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

Вы можете конвертировать слайд в объект Images, а затем использовать объект напрямую где-то. Или вы можете конвертировать слайд в Images и затем сохранить изображение в формате JPEG или любом другом формате, который вам нравится.

{{% /alert %}}  

## **Конвертация слайдов в изображения с пользовательскими размерами**

Вам может понадобиться получить изображение определенного размера. Используя перегрузку метода [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) вы можете конвертировать слайд в изображение с конкретными размерами (длина и ширина).

Этот образец кода демонстрирует предлагаемую конвертацию, используя метод [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) на Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Конвертирует первый слайд презентации в Bitmap с указанным размером
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

## **Конвертация слайдов с заметками и комментариями в изображения**

Некоторые слайды содержат заметки и комментарии.

Aspose.Slides предоставляет два интерфейса — [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) и [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions) — которые позволяют вам контролировать отрисовку слайдов презентации в изображения. Оба интерфейса содержат интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions), который позволяет вам добавлять заметки и комментарии на слайд при конвертации этого слайда в изображение.

{{% alert title="Информация" color="info" %}} 

С помощью интерфейса [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) вы можете указать предпочитаемую позицию для заметок и комментариев в итоговом изображении.

{{% /alert %}} 

Этот код на Java демонстрирует процесс конвертации слайда с заметками и комментариями:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // Создает параметры рендеринга
    IRenderingOptions options = new RenderingOptions();

    // Устанавливает позицию заметок на странице
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // Устанавливает позицию комментариев на странице 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // Устанавливает ширину области вывода комментариев
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // Устанавливает цвет области комментариев
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // Конвертирует первый слайд презентации в объект Bitmap
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

Этот код на Java демонстрирует процесс конвертации слайда с заметками, используя метод [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-):

``` java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// Получает размер заметок презентации
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// Создает параметры рендеринга
	IRenderingOptions options = new RenderingOptions();

	// Устанавливает позицию заметок
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Создает Images с размером заметок
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, notesSize);

	// Сохраняет изображение в PNG формате
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

В любом процессе конвертации слайда в изображение свойство [NotesPositions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) не может быть установлено на BottomFull (для указания позиции заметок), поскольку текст заметки может быть большим, что означает, что он может не вписаться в указанный размер изображения.

{{% /alert %}} 

## **Конвертация слайдов в изображения с использованием ITiffOptions**

Интерфейс [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) дает вам больше контроля (в терминах параметров) над итоговым изображением. С помощью этого интерфейса вы можете указать размер, разрешение, цветовую палитру и другие параметры для итогового изображения.

Этот код на Java демонстрирует процесс конвертации, когда используется ITiffOptions для вывода черно-белого изображения с разрешением 300dpi и размером 2160 × 2800:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// Получает слайд по его индексу
	ISlide slide = pres.getSlides().get_Item(0);

	// Создает объект TiffOptions
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// Устанавливает шрифт, используемый в случае, если исходный шрифт не найден
	options.setDefaultRegularFont("Arial Black");

	// Устанавливает позицию заметок на странице
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Устанавливает формат пикселей (черно-белый)
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// Устанавливает разрешение
	options.setDpiX(300);
	options.setDpiY(300);

	// Конвертирует слайд в объект Bitmap
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

Поддержка Tiff не гарантируется в версиях, выпускаемых ранее JDK 9.

{{% /alert %}} 

## **Конвертация всех слайдов в изображения**

Aspose.Slides позволяет вам конвертировать все слайды в одной презентации в изображения. По сути, вы можете конвертировать презентацию (в целом) в изображения.

Этот образец кода показывает, как конвертировать все слайды в презентации в изображения на Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Отрисовывает презентацию в массив изображений слайд за слайдом
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // Контролирует скрытые слайды (не отрисовывает скрытые слайды)
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // Конвертирует слайд в объект Bitmap
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