---
title: Управление SmartArt
type: docs
weight: 10
url: /ru/python-net/manage-smartart/
keywords: "SmartArt, текст из SmartArt, диаграмма типа организация, организационная диаграмма, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "SmartArt и организационная диаграмма в презентациях PowerPoint на Python"
---

## **Получить текст из SmartArt**
Теперь свойство TextFrame было добавлено в интерфейс ISmartArtShape и класс SmartArtShape соответственно. Это свойство позволяет получать весь текст из SmartArt, если он содержит не только текст узлов. Следующий пример кода поможет вам получить текст из узла SmartArt.

```py
import aspose.slides as slides

with slides.Presentation(path + "SmartArt.pptx") as pres:
    slide = pres.slides[0]
    smartArt = slide.shapes[0]

    for smartArtNode in smartArt.all_nodes:
        for nodeShape in smartArtNode.shapes:
            if nodeShape.text_frame != None:
                print(nodeShape.text_frame.text)
```



## **Изменить тип макета SmartArt**
Чтобы изменить тип макета SmartArt, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на слайд, используя его индекс.
- Добавьте SmartArt BasicBlockList.
- Измените LayoutType на BasicProcess.
- Запишите презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя формами.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Добавить SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Изменить LayoutType на BasicProcess
    smart.layout = art.SmartArtLayoutType.BASIC_PROCESS
    # Сохранение презентации
    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Проверить скрытое свойство SmartArt**
Обратите внимание, что метод com.aspose.slides.ISmartArtNode.isHidden() возвращает true, если этот узел является скрытым узлом в модели данных. Чтобы проверить скрытое свойство любого узла SmartArt, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Добавьте SmartArt RadialCycle.
- Добавьте узел на SmartArt.
- Проверьте свойство isHidden.
- Запишите презентацию в файл PPTX.

В приведенном ниже примере мы добавили соединитель между двумя формами.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Добавить SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.RADIAL_CYCLE)
    # Добавить узел на SmartArt 
    node = smart.all_nodes.add_node()
    # Проверить свойство isHidden
    if node.is_hidden:
        print("скрыт")
        # Выполнить некоторые действия или уведомления
    # Сохранение презентации
    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Получить или установить тип организационной диаграммы**
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) позволяют получить или установить тип организационной диаграммы, связанный с текущим узлом. Чтобы получить или установить тип организационной диаграммы, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Добавьте SmartArt на слайд.
- Получите или установите тип организационной диаграммы.
- Запишите презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя формами.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Добавить SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.ORGANIZATION_CHART)
    # Получить или установить тип организационной диаграммы 
    smart.nodes[0].organization_chart_layout = art.OrganizationChartLayoutType.LEFT_HANGING
    # Сохранение презентации
    presentation.save("OrganizeChartLayoutType_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Создать организационную диаграмму на основе изображений**
Aspose.Slides для Python через .NET предоставляет простой API для создания организационных диаграмм на основе изображений удобным образом. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с умолчательными данными вместе с желаемым типом (ChartType.PictureOrganizationChart).
1. Запишите измененную презентацию в файл PPTX.

Следующий код используется для создания диаграммы.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as pres:
    smartArt = pres.slides[0].shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    pres.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```