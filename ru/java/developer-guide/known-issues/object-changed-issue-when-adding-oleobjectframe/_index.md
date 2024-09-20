---
title: Проблема с изменением объекта при добавлении OleObjectFrame
type: docs
weight: 10
url: /java/object-changed-issue-when-adding-oleobjectframe/
---

## **Описание проблемы**
Когда разработчики добавляют **OleObjectFrame** на свои слайды с помощью Aspose.Slides для Java, на выходном слайде вместо **OLE Object** отображается сообщение **Object Changed**. Большинство клиентов Aspose.Slides для Java считает это ошибкой или багом в Aspose.Slides для Java.
## **Критический анализ и объяснение**
Прежде всего, важно знать, что сообщение **Object Changed**, показанное Aspose.Slides для Java после добавления **OleObjectFrame** на слайд, **НЕ** является ошибкой или багом в Aspose.Slides для Java. Это просто информация или сообщение, уведомляющее пользователей о том, что объект изменен, и изображение должно быть обновлено.

Например, если вы добавите **Microsoft Excel Chart** в качестве **OleObjectFrame** на свой слайд (для получения дополнительных сведений и примера кода о добавлении **OleObjectFrame** на слайд, [нажмите здесь](/slides/java/adding-frame-to-the-slide/)) и затем откроете файл презентации с помощью MS PowerPoint, то слайд (на который был добавлен **OLE Object**) будет выглядеть следующим образом:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**Рисунок**: Слайд, показывающий сообщение **Object Changed** после добавления **OLE Object**

Это не ошибка, и ваш OLE-объект все еще добавлен на слайд. Если вы хотите это протестировать, то **Дважды щелкните** на сообщении **Object Changed** или **Щелкните правой кнопкой мыши** на нем и выберите опцию **Worksheet Object -> Edit**, как показано на рисунке ниже:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**Рисунок**: Выбор опции **Edit** для редактирования **OLE Object**

После выбора опции **Edit** в контекстном меню, вы увидите, что **Embedded OLE Object** станет видимым в редактируемом виде, как показано ниже:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**Рисунок**: **OLE Object** в редактируемом виде

Вы все еще можете увидеть сообщение **Object Changed** на слайде в **Левой панели** MS PowerPoint, которая показывает предварительные просмотры слайдов. Как только вы щелкнете на **OLE Object**, вы увидите, что предварительный просмотр слайда также изменится, и сообщение **Changed Object** будет заменено изображением **OLE Object**, как показано ниже:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**Рисунок**: Обновление изображения **OLE Object**

Теперь вы должны **Сохранить** свой файл презентации с помощью MS PowerPoint, чтобы изображение **OLE Object** было обновлено. После сохранения вашей презентации и повторного открытия в MS PowerPoint вы увидите, что сообщения **Object Changed** больше не будет.
## **Дополнительные решения**
В вышеупомянутом критическом анализе мы продемонстрировали, что изображение **OLE Object** можно обновить, открыв файл презентации в MS PowerPoint и затем сохранив его. Однако есть еще два решения для устранения сообщения **Object Changed**.
## **1-е решение: Заменить сообщение Object Changed изображением**
Если вам не нравится сообщение **Object Changed**, то вы также можете заменить это сообщение своим собственным изображением. Вы можете добавить любое желаемое изображение в свою презентацию, а затем использовать идентификатор этого добавленного изображения, чтобы заменить сообщение **Object Changed**.

Для достижения этого вы можете добавить несколько строк кода в ваше приложение после добавления **OleObjectFrame** на ваш слайд.
## **Пример**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

После добавления вышеуказанных строк в ваше приложение, результирующий слайд, содержащий **OleObjectFrame**, будет выглядеть так:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**Рисунок**: Сообщение **Object Changed** заменено изображением
## **2-е решение: Создание дополнения для MS PowerPoint**
Вы также можете попробовать создать дополнение для MS PowerPoint, которое обновляет все **OLE объекты**, когда вы открываете презентацию в MS PowerPoint.