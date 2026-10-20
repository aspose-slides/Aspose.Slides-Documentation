---
title: Ограничение редактирования презентаций с помощью блокировок форм в C++
linktitle: Ограничить редактирование презентаций
type: docs
weight: 10
url: /ru/cpp/applying-protection-to-presentation/
keywords:
- предотвращение правок
- защита от редактирования
- блокировка формы
- блокировка положения
- блокировка выбора
- блокировка изменения размера
- блокировка группировки
- PowerPoint
- PPTX
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать формы в PPTX‑презентациях с помощью Aspose.Slides для C++, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Фон**

Распространённое применение Aspose.Slides for C++ — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений форм позволяет сохранить задуманную компоновку и содержание.

В этой статье объясняется, как формы организованы на слайдах и как применять и удалять блокировки форм в презентации PPTX. Эти блокировки позволяют ограничить определённые операции редактирования отдельных форм.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автографика, таблицы, OLE‑объекты, сгруппированные формы, рамки изображений, видеорамки, соединители и другие элементы, используемые при построении презентации. В Aspose.Slides for C++ каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) или наследующим класс, реализующий его.

Разные типы форм предоставляют различные параметры блокировки. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) является базовым интерфейсом для блокировок форм. Aspose.Slides for C++ предоставляет следующие интерфейсы блокировок:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) блокирует автографику.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) блокирует соединительные формы.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) блокирует графические объекты.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) блокирует групповые формы.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) блокирует рамки изображений.

Чтобы применить блокировки к всей [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), пройдитесь по её слайдам и установите соответствующие блокировки для каждой поддерживаемой формы.

## **Применение и удаление защиты**

Блокировки форм ограничивают операции, такие как выбор, перемещение и изменение размеров форм. Они не делают всю презентацию недоступной для редактирования.

### **Применение защиты к формам PPTX**

Aspose.Slides for C++ предоставляет интерфейс [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) для работы с формами на слайде.

В примере значение `true` передаётся методам [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) и [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) для автографики, а эквивалентные блокировки применяются к групповым формам, соединителям и рамкам изображений. Для перемещения соединители используют [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/); группы также используют [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) для ограничения группировки.

В примере загружается существующая PPTX‑презентация, проверяются формы в коллекции форм каждого слайда и сохраняется копия с применёнными ограничениями. Формы, которые не относятся к четырём обрабатываемым типам, остаются без изменений. Цикл не проходит по дочерним формам внутри группы.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Удаление защиты**

Чтобы удалить блокировку формы, установите её значение в `false`. В следующем примере загружается презентация с блокировками форм и очищаются ограничения выбора, перемещения и изменения размера через [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) и [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Также очищается [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) и сохраняется копия презентации. Другие параметры блокировок остаются без изменений.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Заключение**

Aspose.Slides for C++ позволяет ограничить определённые операции редактирования отдельных форм или применить одинаковые ограничения к нескольким слайдам. Выбирайте блокировки, поддерживаемые каждым типом формы, и устанавливайте их значения в `false`, когда необходимо снять эти ограничения.

## **Часто задаваемые вопросы**

**Могу ли я комбинировать блокировки форм и защиту паролем в одной презентации?**

Да. Блокировки форм ограничивают определённые операции редактирования, в то время как [защита паролем](/slides/ru/cpp/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать оба метода в одном файле.

**Могу ли я ограничить редактирование на отдельных слайдах, не затрагивая другие?**

Да. Применяйте блокировки только к формам на выбранных слайдах. Это не меняет настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным формам внутри группы?**

Пройдитесь по коллекции, возвращаемой методом [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) группы, и примените соответствующие блокировки к каждой дочерней форме. Повторите это для всех вложенных групп. Приведённые выше примеры обрабатывают только коллекцию форм слайда, поэтому они не устанавливают блокировки для отдельных членов группы.