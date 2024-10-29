---
title: Управление SmartArt
type: docs
weight: 10
url: /ru/cpp/manage-smartart/
---

## **Получить текст из SmartArt**
Теперь свойство TextFrame было добавлено в интерфейс ISmartArtShape и класс SmartArtShape соответственно. Это свойство позволяет вам получить весь текст из SmartArt, если в нем есть не только текст узлов. Приведенный пример кода поможет вам получить текст из узла SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **Изменить тип макета любого SmartArt**
Чтобы изменить тип макета SmartArt, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте SmartArt BasicBlockList.
- Измените LayoutType на BasicProcess.
- Сохраните презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Проверить скрытое свойство SmartArt**
Обратите внимание, что метод com.aspose.slides.ISmartArtNode.isHidden() возвращает true, если этот узел является скрытым узлом в модели данных. Чтобы проверить скрытое свойство любого узла SmartArt, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Добавьте SmartArt RadialCycle.
- Добавьте узел на SmartArt.
- Проверьте свойство isHidden.
- Запишите презентацию в файл PPTX.

В приведенном ниже примере мы добавили соединитель между двумя фигурами.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **Получить или установить тип организационной диаграммы**
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) позволяют получить или установить тип организационной диаграммы, связанный с текущим узлом. Чтобы получить или установить тип организационной диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Добавьте SmartArt на слайд.
- Получите или установите тип организационной диаграммы.
- Запишите презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **Получить или установить состояние SmartArt**
Некоторые диаграммы SmartArt не поддерживают реверсирование, например, вертикальный список маркеров, вертикальный процесс, нисходящий процесс, воронка, шестерня, баланс, круговые отношения, кластер из шестиугольников, обратный список, сложенный Венн. Чтобы изменить ориентацию SmartArt, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Добавьте SmartArt на слайд.
- Получите или установите состояние диаграммы SmartArt.
- Запишите презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Создать организационную диаграмму с картинкой**
Aspose.Slides для C++ предоставляет простой API для создания диаграмм и диаграмм PictureOrganization простым способом. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию с желаемым типом (ChartType.PictureOrganizationChart).
1. Запишите измененную презентацию в файл PPTX.

Следующий код используется для создания диаграммы.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```