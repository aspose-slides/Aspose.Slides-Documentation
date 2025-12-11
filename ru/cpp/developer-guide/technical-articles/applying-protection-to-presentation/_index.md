---
title: Запретить редактирование презентаций с помощью блокировки фигур
linktitle: Запретить редактирование презентации
type: docs
weight: 10
url: /ru/cpp/applying-protection-to-presentation/
keywords:
- предотвратить изменения
- защитить от редактирования
- заблокировать фигуру
- заблокировать позицию
- заблокировать выбор
- заблокировать размер
- заблокировать группировку
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for C++ блокирует и разблокирует фигуры в файлах PPT, PPTX и ODP, обеспечивая безопасность презентаций при возможности контролируемого редактирования и более быстрой поставки."
---

## **Фон**

Распространенный сценарий использования Aspose.Slides — создание, обновление и сохранение презентаций Microsoft PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложений, использующих Aspose.Slides таким образом, получают доступ к сгенерированным презентациям, поэтому защита их от редактирования является актуальной задачей. Важно, чтобы автоматически созданные презентации сохраняли исходное форматирование и содержимое.

Эта статья объясняет, как построены презентации и слайды, и как Aspose.Slides for C++ может применить защиту к презентации и затем снять её. Она предоставляет разработчикам способ контролировать использование презентаций, генерируемых их приложениями.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автофигуры, таблицы, OLE‑объекты, сгруппированные фигуры, рамки изображений, видеорамки, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for C++ каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) или наследующимся от класса, реализующего его.

Структура PPTX сложна, поэтому, в отличие от PPT, где можно использовать один универсальный замок для всех типов фигур, разные типы фигур требуют разных замков. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) является универсальным классом блокировки для PPTX. В Aspose.Slides for C++ для PPTX поддерживаются следующие типы замков:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) блокирует автофигуры.  
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) блокирует фигурные соединители.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) блокирует группы фигур.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) блокирует рамки изображений.   

Любое действие, выполненное над всеми объектами фигур в объекте [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), применяется ко всей презентации.

## **Применение и снятие защиты**

Применение защиты гарантирует, что презентацию нельзя будет редактировать. Это полезная техника для защиты содержимого презентации.

### **Применить защиту к фигурам PPTX**

Aspose.Slides for C++ предоставляет интерфейс [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) для работы с фигурами на слайде.

Как упоминалось ранее, каждый класс фигуры имеет ассоциированный класс блокировки фигуры для защиты. В этой статье рассматриваются блокировки NoSelect, NoMove и NoResize. Эти блокировки гарантируют, что фигуры нельзя будет выбрать (через щелчки мышью или другими методами выбора) и что их нельзя будет переместить или изменить размер.

Пример кода, приведённый ниже, применяет защиту ко всем типам фигур в презентации.
```cpp
// Создать объект класса Presentation, представляющий файл PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Перебор всех слайдов в презентации.
for (auto&& slide : presentation->get_Slides())	{

	// Перебор всех фигур на слайде.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Приведение типа фигуры к автофигуре и получение её блокировки.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Приведение типа фигуры к групповой фигуре и получение её блокировки.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Приведение типа фигуры к соединительной фигуре и получение её блокировки.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Приведение типа фигуры к рамке изображения и получение её блокировки.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Сохранение файла презентации.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **Снять защиту**

Чтобы разблокировать фигуру, установите значение соответствующего замка в `false`. Следующий пример кода показывает, как разблокировать фигуры в заблокированной презентации.
```cpp
// Создать объект класса Presentation, представляющий файл PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Перебор всех слайдов в презентации.
for (auto&& slide : presentation->get_Slides())	{

	// Перебор всех фигур на слайде.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Приведение типа фигуры к автофигуре и получение её блокировки.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Приведение типа фигуры к групповой фигуре и получение её блокировки.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Приведение типа фигуры к соединительной фигуре и получение её блокировки.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Приведение типа фигуры к рамке изображения и получение её блокировки.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Сохранение файла презентации.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Заключение**

Aspose.Slides предлагает несколько вариантов защиты фигур в презентации. Вы можете заблокировать отдельную фигуру или пройтись по всем фигурам в презентации и заблокировать каждую, чтобы эффективно обеспечить безопасность всего файла. Защиту можно снять, установив значение замка в `false`.

## **FAQ**

**Могу ли я комбинировать блокировки фигур и парольную защиту в одной презентации?**

Да. Блокировки ограничивают редактирование объектов внутри файла, тогда как [password protection](/slides/ru/cpp/password-protected-presentation/) контролирует доступ к открытию и/или сохранению изменений. Эти механизмы дополняют друг друга и работают совместно.

**Могу ли я ограничить редактирование на конкретных слайдах, не затрагивая остальные?**

Да. Примените блокировки к фигурам на выбранных слайдах; остальные слайды останутся редактируемыми.

**Применяются ли блокировки фигур к сгруппированным объектам и соединителям?**

Да. Поддерживаются отдельные типы блокировок для групп, соединителей, графических объектов и других видов фигур.