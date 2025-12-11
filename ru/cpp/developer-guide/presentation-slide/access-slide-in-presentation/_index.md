---
title: Доступ к слайдам презентации в C++
linktitle: Доступ к слайду
type: docs
weight: 20
url: /ru/cpp/access-slide-in-presentation/
keywords:
- доступ к слайду
- индекс слайда
- идентификатор слайда
- позиция слайда
- изменить позицию
- свойства слайда
- номер слайда
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как получать доступ к слайдам и управлять ими в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Повышайте продуктивность с примерами кода."
---

Aspose.Slides позволяет получать доступ к слайдам двумя способами: по индексу и по идентификатору.

## **Доступ к слайду по индексу**

Все слайды в презентации располагаются численно в порядке позиции слайда, начиная с 0. Первый слайд доступен по индексу 0; второй слайд — по индексу 1; и так далее.

Класс Presentation, представляющий файл презентации, предоставляет все слайды в виде коллекции [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) (коллекции объектов [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)). Этот код C++ показывает, как получить доступ к слайду по его индексу: 
```c++
	// Путь к каталогу документов.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Создаёт экземпляр класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получить ссылку на слайд по его индексу
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```


## **Доступ к слайду по идентификатору**

Каждый слайд в презентации имеет уникальный идентификатор. Вы можете использовать метод [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) (предоставляемый классом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)) для обращения к этому идентификатору. Этот код C++ показывает, как задать действительный идентификатор слайда и получить доступ к этому слайду через метод [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/):
```c++
	// Путь к каталогу документов.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Создаёт экземпляр класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получает ID слайда
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Доступ к слайду по его ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```


## **Изменить позицию слайда**

Aspose.Slides позволяет изменить позицию слайда. Например, вы можете указать, что первый слайд должен стать вторым слайдом.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд (позицию которого вы хотите изменить) через его индекс
1. Установите новую позицию для слайда через свойство [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/). 
1. Сохраните изменённую презентацию.

Этот код C++ демонстрирует операцию, в которой слайд в позиции 1 перемещается в позицию 2:
```c++
	// Путь к каталогу документов.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Создаёт экземпляр класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получает слайд, позицию которого нужно изменить
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Устанавливает новую позицию для слайда
	slide->set_SlideNumber(2);

	// Сохраняет изменённую презентацию
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


Первый слайд стал вторым; второй слайд стал первым. При изменении позиции слайда остальные слайды автоматически корректируются.

## **Задать номер слайда**

Используя свойство [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) (предоставляемое классом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)), вы можете задать новый номер для первого слайда в презентации. Эта операция приводит к пересчёту номеров остальных слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите номер слайда.
1. Установите номер слайда.
1. Сохраните изменённую презентацию.

Этот код C++ демонстрирует операцию, в которой номер первого слайда установлен в 10: 
```c++
	// Путь к каталогу документов.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Создаёт экземпляр класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получает номер слайда
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Устанавливает номер слайда
	pres->set_FirstSlideNumber(2);
	
	// Сохраняет изменённую презентацию
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


Если вы хотите пропустить первый слайд, вы можете начать нумерацию со второго слайда (и скрыть нумерацию для первого слайда) следующим образом:
```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Совпадает ли номер слайда, который видит пользователь, с нулевой индексацией коллекции?**

Номер, отображаемый на слайде, может начинаться с произвольного значения (например, 10) и не обязателен совпадать с индексом; связь регулируется настройкой [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) презентации.

**Влияют ли скрытые слайды на индексацию?**

Да. Скрытый слайд остаётся в коллекции и учитывается при индексации; «скрытый» относится к отображению, а не к его позиции в коллекции.

**Изменяется ли индекс слайда, когда добавляются или удаляются другие слайды?**

Да. Индексы всегда отражают текущее расположение слайдов и пересчитываются при операциях вставки, удаления и перемещения.