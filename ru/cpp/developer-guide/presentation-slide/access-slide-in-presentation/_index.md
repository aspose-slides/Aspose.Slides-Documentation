---
title: Доступ к слайду в презентации
type: docs
weight: 20
url: /ru/cpp/access-slide-in-presentation/
keywords: "Доступ к презентации PowerPoint, Доступ к слайду, Изменение свойств слайда, Изменение позиции слайда, Установка номера слайда, индекса, ID, позиции C++, CPP, Aspose.Slides"
description: "Доступ к слайду PowerPoint по индексу, ID или позиции в C++. Изменение свойств слайда"
---

Aspose.Slides позволяет вам получать доступ к слайдам двумя способами: по индексу и по ID.

## **Доступ к слайду по индексу**

Все слайды в презентации упорядочены по числовому значению позиции слайда, начиная с 0. Первый слайд доступен по индексу 0; второй слайд доступен по индексу 1; и так далее.

Класс Presentation, представляющий файл презентации, предоставляет все слайды в виде коллекции [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) (коллекция объектов [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)). Этот код на C++ показывает, как получить доступ к слайду через его индекс:

```c++
	// Путь к директории документов.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Создание экземпляра класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получение ссылки на слайд по индексу
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Доступ к слайду по ID**

Каждый слайд в презентации имеет уникальный ID, связанный с ним. Вы можете использовать метод [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) (предоставляемый классом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)), чтобы указать этот ID. Этот код на C++ показывает, как предоставить действительный ID слайда и получить доступ к этому слайду через метод [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// Путь к директории документов.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Создание экземпляра класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получение ID слайда
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Доступ к слайду по его ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Изменение позиции слайда**

Aspose.Slides позволяет изменить позицию слайда. Например, вы можете указать, что первый слайд должен стать вторым слайдом.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд (позицию которого вы хотите изменить) по индексу.
1. Установите новую позицию для слайда через свойство [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/).
1. Сохраните измененную презентацию.

Этот код на C++ демонстрирует операцию, при которой слайд на позиции 1 перемещается на позицию 2:

```c++
	// Путь к директории документов.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Создание экземпляра класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получение слайда, позиция которого будет изменена
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Установка новой позиции для слайда
	slide->set_SlideNumber(2);

	// Сохранение измененной презентации
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Первый слайд стал вторым; второй слайд стал первым. При изменении позиции слайда другие слайды автоматически настраиваются.

## **Установка номера слайда**

Используя свойство [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) (предоставляемое классом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)), вы можете указать новый номер для первого слайда в презентации. Эта операция приводит к перерасчету номеров других слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите номер слайда.
1. Установите номер слайда.
1. Сохраните измененную презентацию.

Этот код на C++ демонстрирует операцию, при которой номер первого слайда устанавливается на 10:

```c++
	// Путь к директории документов.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	// Создание экземпляра класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получение номера слайда
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Установка номера слайда
	pres->set_FirstSlideNumber(2);
	
	// Сохранение измененной презентации
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Если вы предпочитаете пропустить первый слайд, вы можете начать нумерацию со второго слайда (и скрыть нумерацию для первого слайда) таким образом:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Установка номера для первого слайда презентации
presentation->set_FirstSlideNumber(0);

// Показать номера слайдов для всех слайдов
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Скрыть номер слайда для первого слайда
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Сохранение измененной презентации
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```