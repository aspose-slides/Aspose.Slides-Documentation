---
title: Клонирование слайдов
type: docs
weight: 40
url: /ru/cpp/clone-slides/
---


## **Клонирование слайда в презентации**
Клонирование — это процесс создания точной копии или реплики чего-либо. Aspose.Slides для C++ также позволяет создать копию или клонировать любой слайд, а затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайда создает новый слайд, который может быть изменен разработчиками без изменения оригинального слайда. Существует несколько возможных способов клонирования слайда:

- Клонировать в конце презентации.
- Клонировать в другое место в презентации.
- Клонировать в конце другой презентации.
- Клонировать в другое место в другой презентации.
- Клонировать в определенную позицию в другой презентации.

В Aspose.Slides для C++, коллекция [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) объектов, предоставляемая объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), предоставляет методы [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) и [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) для выполнения вышеупомянутых типов клонирования слайдов.

## **Клонировать в конце презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) согласно шагам, перечисленным ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), ссылаясь на коллекцию слайдов, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд для клонирования в качестве параметра методу [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. Запишите изменённый файл презентации.

В приведённом ниже примере мы клонировали слайд (лежащий на первой позиции – нулевой индекс – презентации) в конец презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **Клонировать в другое место в презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом месте, используйте метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Создайте экземпляр класса, ссылаясь на коллекцию **Slides**, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Вызовите метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) объекта [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) и передайте слайд для клонирования вместе с индексом для нового положения в качестве параметра методу [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index).
1. Запишите изменённую презентацию в формате PPTX.

В приведённом ниже примере мы клонировали слайд (лежащий на нулевом индексе – позиция 1 – презентации) на индекс 1 – позицию 2 – презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Клонировать слайд в конец другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий целевую презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), ссылаясь на коллекцию **Slides**, предоставляемую объектом Presentation целевой презентации.
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации в качестве параметра методу [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. Запишите изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Клонировать слайд в другое место в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации в определённом месте:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), ссылаясь на коллекцию Slides, предоставляемую объектом Presentation целевой презентации.
1. Вызовите метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) объекта [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметра методу [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index).
1. Запишите изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) на индекс 1 (позиция 2) целевой презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **Клонировать слайд в определённой позиции в другой презентации**
Если вам нужно клонировать слайд с мастер-слайдом из одной презентации и использовать его в другой презентации, вам необходимо сначала клонировать желаемый мастер-слайд из исходной презентации в целевую презентацию. Затем вам необходимо использовать этот мастер-слайд для клонирования слайда с мастер-слайдом. Метод **AddClone(ISlide, IMasterSlide)** ожидает мастер-слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер-слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий целевую презентацию, в которую будет клонироваться слайд.
1. Получите слайд для клонирования вместе с мастер-слайдом.
1. Создайте экземпляр класса [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection), ссылаясь на коллекцию мастеров, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) целевой презентации.
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) объекта [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) и передайте мастер-слайд из исходного PPTX для клонирования в качестве параметра методу [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), установив ссылку на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) целевой презентации.
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) объекта [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) и передайте слайд из исходной презентации для клонирования и мастер-слайд в качестве параметра методу [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. Запишите изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд с мастер-слайдом (лежащий на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер из исходного слайда.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **Клонировать слайд в заданный раздел**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a46981dac8b18355531a04a70c70c444b), предоставляемый интерфейсом [**ISlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection). Aspose.Slides для C++ позволяет клонировать слайд из первого раздела и затем вставить этот клонированный слайд во второй раздел той же презентации.

Следующий фрагмент кода показывает, как клонировать слайд и вставить клонированный слайд в заданный раздел.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}