---
title: Управление SmartArt в презентациях PowerPoint с использованием C++
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/cpp/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- Тип макета
- Скрытое свойство
- Организационная диаграмма
- Диаграмма организации с изображением
- PowerPoint
- Презентация
- C++
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для C++, используя понятные образцы кода, которые ускоряют разработку слайдов и автоматизацию."
---

## **Получить текст из объекта SmartArt**
Теперь свойство TextFrame добавлено в интерфейс ISmartArtShape и класс SmartArtShape соответственно. Это свойство позволяет получить весь текст из SmartArt, если он содержит не только текст узлов. Приведённый ниже пример кода поможет вам получить текст из узла SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **Изменить тип макета объекта SmartArt**
Чтобы изменить тип макета SmartArt, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте SmartArt BasicBlockList.
- Измените LayoutType на BasicProcess.
- Сохраните презентацию как файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Проверить свойство Hidden объекта SmartArt**
Обратите внимание, что метод com.aspose.slides.ISmartArtNode.isHidden() возвращает true, если этот узел скрыт в модели данных. Чтобы проверить свойство hidden любого узла SmartArt, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Добавьте SmartArt RadialCycle.
- Добавьте узел в SmartArt.
- Проверьте свойство isHidden.
- Сохраните презентацию как файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **Получить или установить тип организационной схемы**
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() и setOrganizationChartLayout(int) позволяют получить или установить тип организационной схемы, связанный с текущим узлом. Чтобы получить или установить тип организационной схемы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Добавьте SmartArt на слайд.
- Получите или установите тип организационной схемы.
- Сохраните презентацию как файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **Получить или установить состояние SmartArt**
Некоторые диаграммы SmartArt не поддерживают обратное отображение, например: Vertical bullet list, Vertical Process, Descending Process, Funnel, Gear, Balance, Circle Relationship, Hexagon Cluster, Reverse List, Stacked Venn. Чтобы изменить ориентацию SmartArt, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Добавьте SmartArt на слайд.
- Получите или установите состояние диаграммы SmartArt.
- Сохраните презентацию как файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Создать диаграмму Picture Organization**
Aspose.Slides for C++ предоставляет простой API для создания диаграмм PictureOrganization простым способом. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию, указав нужный тип (ChartType.PictureOrganizationChart).
4. Сохраните изменённую презентацию в файл PPTX

Следующий код используется для создания диаграммы.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```


## **Вопросы и ответы**

**Поддерживает ли SmartArt зеркальное/обратное отображение для языков RTL?**

Да. Метод [set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) переключает направление диаграммы (LTR/RTL), если выбранный тип SmartArt поддерживает обратное отображение.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/cpp/shape-manipulations/) через коллекцию фигур ([ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/)) или [клонировать весь слайд](/slides/ru/cpp/clone-slides/), содержащий эту форму. Оба подхода сохраняют размер, положение и стиль.

**Как отрендерить SmartArt в растровое изображение для предварительного просмотра или экспорта в веб?**

[Отрендерите слайд](/slides/ru/cpp/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG с помощью API, который преобразует слайды/презентации в изображения — SmartArt будет отрисован как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Обычной практикой является использование [альтернативного текста](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) (Alt Text) или [имени](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) и поиск формы по этому атрибуту в [формах слайда](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), затем проверка типа, чтобы убедиться, что это [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/). Документация описывает типичные техники поиска и работы с формами.