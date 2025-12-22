---
title: Многопоточность в Aspose.Slides для Android via Java
linktitle: Многопоточность
type: docs
weight: 310
url: /ru/androidjava/multithreading/
keywords:
- многопоточность
- множество потоков
- параллельная работа
- конвертация слайдов
- слайды в изображения
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Многопоточность Aspose.Slides for Android via Java ускоряет обработку PowerPoint и OpenDocument. Узнайте лучшие практики для эффективных рабочих процессов презентаций."
---

## **Введение**

Хотя параллельная работа с презентациями возможна (кроме парсинга/загрузки/клонирования) и обычно всё проходит хорошо (в большинстве случаев), существует небольшая вероятность получения некорректных результатов при использовании библиотеки в нескольких потоках.

Мы настоятельно рекомендуем **не** использовать один экземпляр [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) в многопоточном окружении, поскольку это может привести к непредсказуемым ошибкам или сбоям, которые трудно обнаружить.

Загрузка, сохранение и/или клонирование экземпляра класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) в нескольких потоках **не** являются безопасными. Такие операции **не** поддерживаются. Если необходимо выполнить такие задачи, следует распараллелить их, используя несколько одноточных процессов, и каждый процесс должен использовать собственный экземпляр презентации.

## **Параллельное преобразование слайдов презентации в изображения**

Допустим, нам нужно параллельно преобразовать все слайды презентации PowerPoint в PNG‑изображения. Поскольку использовать один экземпляр `Presentation` в нескольких потоках небезопасно, мы делим слайды презентации на отдельные презентации и параллельно конвертируем слайды в изображения, используя каждую презентацию в отдельном потоке. Ниже приведён пример кода, показывающий, как это сделать.
```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Извлечь слайд i в отдельную презентацию.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Преобразовать слайд в изображение в отдельной задаче.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// Ожидать завершения всех задач.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```


## **Часто задаваемые вопросы**

**Нужно ли вызывать настройку лицензии в каждом потоке?**

Нет. Достаточно выполнить её один раз на процесс/домейн приложения до запуска потоков. Если [license setup](/slides/ru/androidjava/licensing/) может вызываться одновременно (например, при ленивой инициализации), синхронизируйте этот вызов, так как метод настройки лицензии сам по себе не является потокобезопасным.

**Можно ли передавать объекты `Presentation` или `Slide` между потоками?**

Передача «живых» объектов презентации между потоками не рекомендуется: используйте независимые экземпляры для каждого потока или заранее создайте отдельные презентации/контейнеры слайдов для каждого потока. Такой подход соответствует общему совету не делиться одним экземпляром презентации между потоками.

**Безопасно ли параллельно экспортировать в различные форматы (PDF, HTML, изображения), если у каждого потока свой экземпляр `Presentation`?**

Да. При использовании независимых экземпляров и отдельных путей вывода такие задачи обычно параллелятся корректно; избегайте совместного использования объектов презентации и общих потоков ввода‑вывода.

**Что делать с глобальными настройками шрифтов (папки, замены) в многопоточности?**

Инициализируйте все глобальные [font settings](/slides/ru/androidjava/powerpoint-fonts/) до запуска потоков и не изменяйте их во время параллельной работы. Это устраняет гонки при доступе к общим ресурсам шрифтов.