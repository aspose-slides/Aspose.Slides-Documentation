---
title: Удалить слайд из презентации
type: docs
weight: 30
url: /cpp/remove-slide-from-presentation/
keywords: "Удалить слайд, Удалить слайд, PowerPoint, Презентация, C++, Aspose.Slides"
description: "Удалить слайд из PowerPoint по ссылке или индексу на C++"

---

Если слайд (или его содержимое) становится избыточным, вы можете удалить его. Aspose.Slides предоставляет класс [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), который инкапсулирует [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/), который является хранилищем для всех слайдов в презентации. Используя указатели (ссылка или индекс) для известного объекта [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/), вы можете указать слайд, который хотите удалить.

## **Удалить слайд по ссылке**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд, который хотите удалить, через его ID или индекс.
1. Удалите указанный слайд из презентации.
1. Сохраните измененную презентацию.

Этот код на C++ показывает, как удалить слайд по его ссылке: 

```c++
	// Путь к директории документов
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Создает объект Presentation, представляющий файл презентации
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получает слайд через его индекс в коллекции слайдов
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Удаляет слайд по его ссылке
	pres->get_Slides()->Remove(slide);

	// Сохраняет измененную презентацию
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Удалить слайд по индексу**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Удалите слайд из презентации по его индексу.
1. Сохраните измененную презентацию.

Этот код на C++ показывает, как удалить слайд по его индексу: 

```c++
	// Путь к директории документов
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Создает объект Presentation, представляющий файл презентации
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Удаляет слайд по его индексу
	pres->get_Slides()->RemoveAt(0);

	// Сохраняет измененную презентацию
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Удалить неиспользуемый макет слайда**

Aspose.Slides предоставляет метод [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (из класса [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)), который позволяет вам удалять нежелательные и неиспользуемые макеты слайдов. Этот код на C++ показывает, как удалить макет слайда из презентации PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Удалить неиспользуемый мастер-слайд**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (из класса [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)), который позволяет вам удалять нежелательные и неиспользуемые мастер-слайды. Этот код на C++ показывает, как удалить мастер-слайд из презентации PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```