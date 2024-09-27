---
title: Макет слайда
type: docs
weight: 60
url: /ru/cpp/slide-layout/
keyword: "Установить размер слайда, установить параметры слайда, указать размер слайда, Видимость нижнего колонтитула, Дочерний нижний колонтитул, Масштабирование содержимого, размер страницы, C++, CPP, Aspose.Slides"
description: "Установить размер слайда PowerPoint и параметры в C++"
---

Макет слайда содержит заполнитель и информацию о форматировании для всего содержимого, которое появляется на слайде. Макет определяет доступные заполнители содержимого и их размещение.

Макеты слайдов позволяют быстро создавать и разрабатывать презентации (независимо от того, простые они или сложные). Вот некоторые из самых популярных макетов слайдов, используемых в презентациях PowerPoint:

* **Макет титульного слайда**. Этот макет состоит из двух заполнителей текста. Один заполнитель предназначен для заголовка, а другой – для подзаголовка.
* **Макет заголовка и содержимого**. Этот макет содержит относительно небольшой заполнитель вверху для заголовка и больший заполнитель для основного содержимого (графика, параграфы, маркированный список, нумерованный список, изображения и т. д.).
* **Пустой макет**. Этот макет не содержит заполнителей, поэтому позволяет создавать элементы с нуля.

Поскольку мастер-слайд является верхним иерархическим слайдом, который хранит информацию о макетах слайдов, вы можете использовать мастер-слайд для доступа к макетам слайдов и внесения изменений в них. Макет слайда можно получить по типу или имени. Аналогично, каждый слайд имеет уникальный идентификатор, который можно использовать для доступа к нему.

Кроме того, вы можете вносить изменения напрямую в конкретный макет слайда в презентации.

* Чтобы позволить вам работать с макетами слайдов (включая те, что находятся в мастер-слайдах), Aspose.Slides предоставляет свойства, такие как [get_LayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) и [get_Masters()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) в классе [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
* Для выполнения связанных задач Aspose.Slides предоставляет [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/baseslideheaderfootermanager/) и многие другие типы.

{{% alert title="Информация" color="info" %}}

Для получения более подробной информации о работе с мастер-слайдами в частности, смотрите статью [Мастер-слайд](https://docs.aspose.com/slides/cpp/slide-master/).

{{% /alert %}}

## **Добавить макет слайда в презентацию**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите доступ к [коллекции MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Просмотрите существующие макеты слайдов, чтобы подтвердить, что необходимый макет слайда уже существует в коллекции макетов слайдов. В противном случае добавьте нужный макет слайда.
1. Добавьте пустой слайд на основе нового макета слайда.
1. Сохраните презентацию.

Этот код на C++ показывает, как добавить макет слайда в презентацию PowerPoint:

```c++
	// Путь к директории документов.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/AddLayoutSlides.pptx";

	// Создает экземпляр класса Presentation, который представляет файл презентации.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Проходит через типы макетов слайдов.
	SharedPtr<IMasterLayoutSlideCollection> layoutSlides = pres->get_Masters()->idx_get(0)->get_LayoutSlides();

	SharedPtr<ILayoutSlide> layoutSlide;
	if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
	}
	else if (layoutSlides->GetByType(SlideLayoutType::Title) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
	}

	if (layoutSlide == NULL)
	{
		// Ситуация, когда презентация не содержит некоторые типы макетов.
		// Файл презентации содержит только пустые и пользовательские типы макетов.
		// Но макеты слайдов с пользовательскими типами имеют разные имена слайдов,
		// такие как "Заголовок", "Заголовок и содержимое" и т. д. И эти
		// имена можно использовать для выбора макета слайда.
		// Вы также можете использовать набор типов заполнителей форм. Например,
		// титульный слайд должен иметь только тип заполнителя "Заголовок" и т. д.

		for (int i = 0; i < layoutSlides->get_Count(); i++)
		{
			SharedPtr<ILayoutSlide> titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

			if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
			{
				layoutSlide = titleAndObjectLayoutSlide;
				break;
			}
		}

		if (layoutSlide == NULL)
		{
			for (int i = 0; i < layoutSlides->get_Count(); i++)
			{
				SharedPtr<ILayoutSlide> titleLayoutSlide = layoutSlides->idx_get(i);

				if (titleLayoutSlide->get_Name().Equals(u"Title"))
				{
					layoutSlide = titleLayoutSlide;
					break;
				}
			}

			if (layoutSlide == NULL)
			{
				layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
				if (layoutSlide == NULL)
				{
					layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
				}
			}
		}
	}

	// Добавляет пустой слайд с добавленным макетом слайда.
	pres->get_Slides()->InsertEmptySlide(0, layoutSlide);

	// Сохраните презентацию на диск.
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Удалить неиспользуемый макет слайда**

Aspose.Slides предоставляет метод [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) из класса [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/), который позволяет вам удалять ненужные и неиспользуемые макеты слайдов. Этот код на C++ показывает, как удалить макет слайда из презентации PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);

```

## **Установить размер и тип для макета слайда**

Чтобы установить размер и тип для конкретного макета слайда, Aspose.Slides предоставляет свойства [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) и [get_Size()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_size/) (из класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)). Этот C++ код демонстрирует операцию:

```c++
	// Путь к директории документов.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/CloneToAnotherPresentationWithSetSizeAndType.pptx";
	// Создает объект Presentation, который представляет файл презентации.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	SharedPtr<Presentation> destPres = MakeObject<Presentation>();

	// Получает слайды по идентификатору из коллекции.
	SharedPtr<ISlideCollection> slideCollection = destPres->get_Slides();
	
	// Устанавливает размер слайда для сгенерированной презентации в соответствии с размером источника.
	destPres->get_SlideSize()->SetSize(pres->get_SlideSize()->get_Type(), Aspose::Slides::SlideSizeScaleType::DoNotScale);

	slideCollection->InsertClone(1, pres->get_Slides()->idx_get(0));

	// Сохраняет презентацию на диск.
	destPres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Установить видимость нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Установите заполнитель нижнего колонтитула слайда в видимый режим.
1. Установите заполнитель даты и времени в видимый режим.
1. Сохраните презентацию.

Этот код на C++ показывает, как установить видимость для нижнего колонтитула слайда (и выполнить связанные задачи):

```c++
 // Путь к директории документов.
const String outPath = u"../out/HeaderFooterManager_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Создает класс SlideCollection.
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

//	SharedPtr<IBaseSlideHeaderFooterManager> headerFooterManager = presentation->get_Slides()->idx_get(0)->get_HeaderFooterManager();
SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
if (!headerFooterManager->get_IsFooterVisible()) // Свойство IsFooterVisible используется для указания на отсутствие заполнителя нижнего колонтитула слайда.
{
	headerFooterManager->SetFooterVisibility(true); // Метод SetFooterVisibility используется для установки видимости заполнителя нижнего колонтитула слайда.
}
if (!headerFooterManager->get_IsSlideNumberVisible()) // Свойство IsSlideNumberVisible используется для указания, что заполнителя номера страницы слайда отсутствует.
{
	headerFooterManager->SetSlideNumberVisibility(true); // Метод SetSlideNumberVisibility используется для установки видимости заполнителя номера страницы слайда.
}
if (!headerFooterManager->get_IsDateTimeVisible()) // Свойство IsDateTimeVisible используется для указания, что заполнителя даты и времени слайда отсутствует.
{
	headerFooterManager->SetDateTimeVisibility(true); // Метод SetFooterVisibility используется для установки видимости заполнителя даты и времени слайда.
}
headerFooterManager->SetFooterText(u"Текст нижнего колонтитула"); // Метод SetFooterText используется для установки текста для заполнителя нижнего колонтитула слайда.
headerFooterManager->SetDateTimeText(u"Текст даты и времени"); // Метод SetDateTimeText используется для установки текста для заполнителя даты и времени слайда.


// Сохраняет презентацию на диск.
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Установить видимость дочернего нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на мастер-слайд по индексу.
1. Установите мастер-слайд и все заполнители дочерних нижних колонтитулов в видимый режим.
1. Установите текст для мастер-слайда и всех заполнителей дочерних нижних колонтитулов.
1. Установите текст для мастер-слайда и всех заполнителей дочерних дат и времени.
1. Сохраните презентацию.

Этот код на C++ демонстрирует операцию:

```c++
// Путь к директории документов.
const String outPath = u"../out/SetChildFooter_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Создает класс SlideCollection.
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true); // Метод SetFooterAndChildFootersVisibility используется для установки мастер-слайда и всех заполнителей дочерних нижних колонтитулов в видимый режим.
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true); // Метод SetSlideNumberAndChildSlideNumbersVisibility используется для установки мастер-слайда и всех заполнителей дочерних номеров страниц в видимый режим.
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true); // Метод SetDateTimeAndChildDateTimesVisibility используется для установки мастер-слайда и всех заполнителей дочерних дат и времени в видимый режим.

headerFooterManager->SetFooterAndChildFootersText(u"Текст нижнего колонтитула"); // Метод SetFooterAndChildFootersText используется для установки текстов для мастер-слайда и всех заполнителей дочерних нижних колонтитулов.
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Текст даты и времени"); // Метод SetDateTimeAndChildDateTimesText используется для установки текста для мастер-слайда и всех заполнителей дочерних дат и времени.

presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Установить размер слайда с учетом масштабирования содержимого**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и загрузите презентацию, содержащую слайд, размер которого вы хотите задать.
1. Создайте другой экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), чтобы создать новую презентацию.
1. Получите ссылку на слайд (из первой презентации) по индексу.
1. Установите заполнитель нижнего колонтитула слайда в видимый режим.
1. Установите заполнитель даты и времени в видимый режим.
1. Сохраните презентацию.

Этот код на C++ демонстрирует операцию:

```c++
// Путь к директории документов.
const String templatePath = u"../templates/AccessSlides.pptx";
const String outPath = u"../out/SetSlideSizeScale_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);
SharedPtr<Presentation> auxPresentation = MakeObject<Presentation>();

// Создает класс SlideCollection.
SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

// Устанавливает размер слайда для созданных презентаций в соответствии с размером источника.
auxPresentation->get_SlideSize()->SetSize(540, 720, SlideSizeScaleType::EnsureFit); // Метод SetSize используется для установки размера слайда с масштабированием содержимого для соответствия размеру.
auxPresentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize); // Метод SetSize используется для установки размера слайда с максимальным размером содержимого.

auxPresentation->get_Slides()->InsertClone(0, slide);
auxPresentation->get_Slides()->RemoveAt(0);

// Сохраняет презентацию.
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Установить размер страницы при генерации PDF**

Некоторые презентации (например, постеры) часто конвертируются в PDF-документы. Если вы хотите преобразовать свою PowerPoint-презентацию в PDF, чтобы использовать наилучшие параметры печати и доступности, вам нужно установить размеры слайдов, соответствующие PDF-документам (например, A4).

Aspose.Slides предоставляет класс [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/), чтобы вы могли указать свои предпочтительные настройки для слайдов. Этот код на C++ показывает, как использовать свойство [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) (из класса `SlideSize`), чтобы установить конкретный размер бумаги для слайдов в презентации:

```c++
// Путь к директории документов.
	const String outPath = u"../out/SetPDFPageSize_out.pptx";

	// Создает объект Presentation, который представляет файл презентации.
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Устанавливает свойство SlideSize.Type.
	pres->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);

	// Устанавливает различные свойства параметров PDF.
	Aspose::Slides::Export::PdfOptions opts = Aspose::Slides::Export::PdfOptions();
	opts.set_SufficientResolution (600);

	// Сохраняет презентацию.
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pdf, &opts);
```