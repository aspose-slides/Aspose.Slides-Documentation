---
title: Клонирование слайдов презентации в C++
linktitle: Клонировать слайды
type: docs
weight: 40
url: /ru/cpp/clone-slides/
keywords:
- клонировать слайд
- копировать слайд
- сохранить слайд
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Быстро дублируйте слайды PowerPoint с помощью Aspose.Slides для C++. Следуйте нашим чистым примерам кода, чтобы автоматизировать создание PPT за секунды и избавиться от ручной работы."
---

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for C++ также позволяет сделать копию или клон любого слайда, а затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который может быть изменён разработчиками без изменения исходного слайда. Существует несколько способов клонирования слайда:

- Клонирование в конце в пределах презентации.
- Клонирование в другой позиции в пределах презентации.
- Клонирование в конце в другой презентации.
- Клонирование в другой позиции в другой презентации.
- Клонирование в конкретной позиции в другой презентации.

В Aspose.Slides for C++ (коллекция[ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)объектов), которую предоставляет объект[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), доступны методы[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/)и[InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/)для выполнения перечисленных типов клонирования слайдов.

## **Клонирование слайда в конце презентации**
Если нужно клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/)согласно приведённым ниже шагам:

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите объект[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)по ссылке на коллекцию Slides, предоставляемую объектом[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Вызовите метод[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/)у объекта[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)и передайте слайд, который нужно клонировать, в качестве параметра методу[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/).
1. Сохраните изменённый файл презентации.

В примере ниже мы клонировали слайд (расположенный на первой позиции — индекс 0 — в презентации) в конец презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Клонирование слайда в другую позицию в пределах презентации**
Если нужно клонировать слайд и затем использовать его в том же файле презентации, но в другой позиции, используйте метод[InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/):

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите объект, ссылаясь на коллекцию**Slides**у объекта[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Вызовите метод[InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/)у объекта[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)и передайте слайд, который нужно клонировать, вместе с индексом новой позиции в качестве параметра методу[InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/).
1. Сохраните изменённую презентацию в файле PPTX.

В примере ниже мы клонировали слайд (расположенный на индексе 0 — позиция 1 — в презентации) в индекс 1 — позиция 2 — презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Клонирование слайда в конец другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), содержащий исходную презентацию.
1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), содержащий целевую презентацию, в которую будет добавлен слайд.
1. Получите объект[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)по ссылке на коллекцию**Slides**у объекта Presentation целевой презентации.
1. Вызовите метод[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/)у объекта[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)и передайте слайд из исходной презентации в качестве параметра методу[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/).
1. Сохраните изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Клонирование слайда в другую позицию в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, в конкретной позиции:

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), содержащий исходную презентацию.
1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), содержащий целевую презентацию.
1. Получите объект[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)по ссылке на коллекцию Slides у объекта Presentation целевой презентации.
1. Вызовите метод[InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/)у объекта[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметра методу[InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/).
1. Сохраните изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Клонирование слайда в конкретной позиции в другой презентации**
Если необходимо клонировать слайд с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно клонировать нужный мастер‑слайд из исходной презентации в целевую. Затем используйте этот мастер‑слайд для клонирования слайда с мастер‑слайдом. Метод**AddClone(ISlide, IMasterSlide)**ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), содержащий исходную презентацию.
1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), содержащий целевую презентацию.
1. Получите доступ к клонируемому слайду вместе с его мастер‑слайдом.
1. Получите объект[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/)по ссылке на коллекцию Masters у объекта[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) целевой презентации.
1. Вызовите метод[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/)у объекта[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) и передайте мастер‑слайд из исходного PPTX в качестве параметра методу[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/).
1. Получите объект[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)по ссылке на коллекцию Slides у объекта[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) целевой презентации.
1. Вызовите метод[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/)у объекта[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) и передайте слайд из исходной презентации и мастер‑слайд в качестве параметров методу[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/).
1. Сохраните изменённый файл целевой презентации.

В примере ниже мы клонировали слайд с мастером (расположенный в нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Клонирование слайда в конец указанного раздела**
Если нужно клонировать слайд и затем использовать его в той же презентации, но в другом разделе, используйте метод[**AddClone()**](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/)у интерфейса[**ISlideCollection**](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ позволяет клонировать слайд из первого раздела и затем вставить его в второй раздел той же презентации.

Следующий фрагмент кода показывает, как клонировать слайд и вставить его в указанный раздел.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**Клонируются ли заметки выступающего и комментарии рецензентов?**

Да. Страницы заметок и комментарии включаются в клон. Если они не нужны, [удалите их](/slides/ru/cpp/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, встраиваемой книгой OLE), эта связь сохраняется как [OLE‑объект](/slides/ru/cpp/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Можно ли управлять позицией вставки и разделами клона?**

Да. Вы можете вставить клон в конкретный индекс слайда и разместить его в выбранном [разделе](/slides/ru/cpp/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд туда.