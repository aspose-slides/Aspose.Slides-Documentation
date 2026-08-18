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
description: "Быстро дублируйте слайды PowerPoint с помощью Aspose.Slides для C++. Следуйте нашим понятным примерам кода, чтобы автоматизировать создание PPT за секунды и избавиться от ручной работы."
---
## **Введение**

Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for C++ также позволяет создать копию или клон любого слайда и затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который может быть изменён разработчиками без изменения оригинального слайда. Существует несколько способов клонирования слайда:

- Клонирование в конце внутри презентации.
- Клонирование в другую позицию внутри презентации.
- Клонирование в конце другой презентации.
- Клонирование в другую позицию в другой презентации.
- Клонирование в определённой позиции в другой презентации.

В Aspose.Slides for C++ (коллекция объектов [ISlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/) ), предоставляемая объектом [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) , предоставляет методы [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) и [InsertClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/insertclone/) для выполнения перечисленных выше типов клонирования слайдов

## **Клонирование слайда в конец презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) в соответствии со следующими шагами:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) , обратившись к коллекции Slides, доступной через объект [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) объекта [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) и передайте слайд, который нужно клонировать, в качестве параметра метода [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) .
1. Запишите изменённый файл презентации.

В примере ниже мы клонировали слайд (находящийся на первой позиции – нулевой индекс – презентации) в конец презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **Клонирование слайда в другую позицию внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другой позиции, используйте метод [InsertClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/insertclone/) :

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
1. Получите объект, обратившись к коллекции **Slides** объекта [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
1. Вызовите метод [InsertClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/insertclone/) объекта [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) и передайте слайд, который нужно клонировать, вместе с индексом новой позиции в качестве параметра метода [InsertClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/insertclone/) .
1. Запишите изменённую презентацию в файл PPTX.

В примере ниже мы клонировали слайд (находящийся на нулевом индексе – позиция 1 – презентации) в индекс 1 – позицию 2 презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Клонирование слайда в конец другой презентации**
Если нужно клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) , содержащего презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) , содержащего целевую презентацию, в которую слайд будет добавлен.
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) , обратившись к коллекции **Slides** объекта Presentation целевой презентации.
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) объекта [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) и передайте слайд из исходной презентации в качестве параметра метода [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) .
1. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Клонирование слайда в другую позицию в другой презентации**
Если нужно клонировать слайд из одной презентации и использовать его в другой презентации, в определённой позиции:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) , содержащего исходную презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) , содержащего презентацию, в которую слайд будет добавлен.
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) , обратившись к коллекции Slides объекта Presentation целевой презентации.
1. Вызовите метод [InsertClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/insertclone/) объекта [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметра метода [InsertClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/insertclone/) .
1. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **Клонирование слайда в определённой позиции в другой презентации**
Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно клонировать требуемый мастер‑слайд из исходной презентации в целевую. Затем используйте этот мастер‑слайд для клонирования слайда с мастер‑слайдом. Метод **AddClone(ISlide, IMasterSlide)** ожидает мастер‑слайд из целевой презентации, а не из источника. Чтобы клонировать слайд с мастер‑слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) , содержащего исходную презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) , содержащего целевую презентацию, в которую будет клонирован слайд.
1. Получите доступ к клонируемому слайду вместе с его мастер‑слайдом.
1. Получите объект [IMasterSlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/) , обратившись к коллекции Masters объекта [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) целевой презентации.
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) объекта [IMasterSlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/) и передайте мастер‑слайд из исходного PPTX в качестве параметра метода [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) .
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) , задав ссылку на коллекцию Slides объекта [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) целевой презентации.
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) объекта [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) и передайте слайд из исходной презентации и мастер‑слайд в качестве параметра метода [AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) .
1. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд с мастер‑слайдом (находящийся на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **Клонирование слайда в конец указанного раздела**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [**AddClone()**](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) интерфейса [**ISlideCollection**](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/) . Aspose.Slides for C++ позволяет клонировать слайд из первого раздела и затем вставить его в второй раздел той же презентации.

Следующий фрагмент кода демонстрирует, как клонировать слайд и вставить клонированный слайд в указанный раздел.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Обеспечение совпадения размера слайдов**

При клонировании слайдов в другую презентацию убедитесь, что у целевой презентации такой же размер слайда, как у исходной. Если размеры слайдов различаются, Aspose.Slides не масштабирует автоматически клонированные объекты — их исходные координаты и размеры сохраняются, что может привести к смещению содержимого или выходу его за границы слайда.

Вы можете установить размер слайда целевой презентации, соответствующий размеру источника, перед клонированием мастера и слайда:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Сделайте это перед клонированием мастера и слайда.

## **FAQ**

**Клонируются ли заметки выступающего и комментарии рецензента?**

Да. Страницы заметок и комментарии включаются в клон. Если они не нужны, [удалите их](/slides/ru/cpp/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, встроенной OLE‑книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/cpp/manage-ole/). После переноса между файлами проверьте доступность данных и поведение обновления.

**Можно ли управлять позицией вставки и разделами клона?**

Да. Вы можете вставить клон в конкретный индекс слайда и разместить его в выбранном [разделе](/slides/ru/cpp/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд туда.