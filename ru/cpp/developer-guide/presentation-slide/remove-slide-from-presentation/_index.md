---
title: Удаление слайдов из презентаций в C++
linktitle: Удалить слайд
type: docs
weight: 30
url: /ru/cpp/remove-slide-from-presentation/
keywords:
- удалить слайд
- удалить слайд
- удалить неиспользуемый слайд
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Легко удаляйте слайды из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Получайте понятные примеры кода и ускоряйте свои рабочие процессы."
---

Если слайд (или его содержимое) становится избыточным, его можно удалить. Aspose.Slides предоставляет класс [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), который инкапсулирует [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/), являющийся репозиторием всех слайдов в презентации. Используя указатели (ссылка или индекс) для известного объекта [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/), можно указать слайд, который требуется удалить. 

## **Remove a Slide by Reference**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд, который хотите удалить, по его ID или Index.
1. Удалите указанный слайд из презентации.
1. Сохраните изменённую презентацию. 

This C++ code shows you how to remove a slide through its reference: 
```c++
	// Путь к каталогу документов
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Создаёт объект Presentation, представляющий файл презентации
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Доступ к слайду через его индекс в коллекции слайдов
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Удаляет слайд через его ссылку
	pres->get_Slides()->Remove(slide);

	// Сохраняет изменённую презентацию
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```



## **Remove a Slide by Index**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Удалите слайд из презентации по его позиции индекса.
1. Сохраните изменённую презентацию. 

This C++ code shows you how to remove a slide through its index: 
```c++
	// Путь к каталогу документов
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Создаёт объект Presentation, представляющий файл презентации
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Удаляет слайд по его индексу
	pres->get_Slides()->RemoveAt(0);

	// Сохраняет изменённую презентацию
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Remove Unused Layout Slides**

Aspose.Slides предоставляет метод [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (из класса [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) для удаления нежелательных и неиспользуемых слайдов‑макетов. Этот код C++ показывает, как удалить слайд‑макет из презентации PowerPoint:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **Remove Unused Master Slides**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (из класса [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) для удаления нежелательных и неиспользуемых слайдов‑мастеров. Этот код C++ показывает, как удалить мастер‑слайд из презентации PowerPoint:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**What happens to slide indexes after I delete a slide?**

После удаления коллекция переиндексируется: каждый последующий слайд сдвигается влево на одну позицию, поэтому прежние номера индексов становятся устаревшими. Если вам нужна стабильная ссылка, используйте постоянный ID слайда вместо его индекса.

**Is a slide’s ID different from its index, and does it change when neighboring slides are deleted?**

Да. Индекс отражает позицию слайда и меняется при добавлении или удалении слайдов. ID слайда является постоянным идентификатором и не меняется при удалении других слайдов.

**How does deleting a slide affect slide sections?**

Если слайд принадлежал секции, в этой секции будет просто на один слайд меньше. Структура секции сохраняется; если секция становится пустой, её можно [remove or reorganize sections](/slides/ru/cpp/slide-section/).

**What happens to notes and comments attached to a slide when it’s deleted?**

[Notes](/slides/ru/cpp/presentation-notes/) и [comments](/slides/ru/cpp/presentation-comments/) привязаны к конкретному слайду и удаляются вместе с ним. Содержимое остальных слайдов не затрагивается.

**How is deleting slides different from cleaning up unused layouts/masters?**

Удаление устраняет конкретные обычные слайды из презентации. Очистка неиспользуемых макетов/мастеров удаляет слайды‑шаблоны макета или мастера, которые больше не используются, тем самым уменьшая размер файла без изменения содержимого оставшихся слайдов. Эти действия дополняют друг друга: обычно сначала удаляют, затем проводят очистку.