---
title: Проблема изменения объекта при добавлении OleObjectFrame
type: docs
weight: 10
url: /ru/androidjava/object-changed-issue-when-adding-oleobjectframe/
---

## **Описание проблемы**
Когда разработчики добавляют **OleObjectFrame** в свои слайды с помощью Aspose.Slides для Android через Java, на выходном слайде вместо **OLE Object** отображается сообщение **Object Changed**. Большинство клиентов Aspose.Slides для Android через Java считает, что это ошибка или сбой в Aspose.Slides для Android через Java.
## **Критический анализ и объяснение**
Прежде всего, важно знать, что сообщение **Object Changed**, отображаемое Aspose.Slides для Android через Java после добавления **OleObjectFrame** в слайд, **НЕ** является ошибкой или сбоем в Aspose.Slides для Android через Java. Это просто информация или сообщение, уведомляющее пользователей о том, что объект изменён и изображение должно быть обновлено.

Например, если вы добавите **Microsoft Excel Chart** в качестве **OleObjectFrame** на свой слайд (для получения более подробной информации и примера кода о добавлении **OleObjectFrame** на слайд, [нажмите здесь](/slides/ru/androidjava/adding-frame-to-the-slide/)) и затем откроете файл презентации с помощью MS PowerPoint, то слайд (на который был добавлен **OLE Object**) будет выглядеть так:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**Рисунок**: Слайд с сообщением **Object Changed** после добавления **OLE Object**

Это не ошибка, и ваш OLE Object по-прежнему добавлен на слайд. Если вы хотите протестировать это, то **Дважды щелкните** на сообщение **Object Changed** или **Щелкните правой кнопкой** на него и выберите опцию **Worksheet Object -> Edit**, как показано на рисунке ниже:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**Рисунок**: Выбор опции **Edit** для редактирования **OLE Object**

После того, как вы выберете опцию **Edit** в контекстном меню, вы увидите, что **Embedded OLE Object** станет видимым в редактируемой форме, как показано ниже:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**Рисунок**: **OLE Object** в редактируемой форме

Вы все еще можете видеть сообщение **Object Changed** на слайде в **Левой панели** MS PowerPoint, которая показывает предварительный просмотр слайдов. Как только вы щелкнете на **OLE Object**, вы увидите, что предварительный просмотр слайда также изменится, и сообщение **Changed Object** будет заменено изображением **OLE Object**, как показано ниже:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**Рисунок**: Обновление изображения **OLE Object**

Теперь вам следует **Сохранить** свой файл презентации с помощью MS PowerPoint, чтобы изображение **OLE Object** было обновлено. После сохранения вашей презентации и повторного открытия её с помощью MS PowerPoint, вы увидите, что сообщение **Object Changed** больше не будет отображаться.
## **Дополнительные решения**
В приведенном выше критическом анализе мы показали, что изображение **OLE Object** может быть обновлено путем открытия файла презентации в MS PowerPoint и его сохранения. Но есть еще два решения для устранения сообщения **Object Changed**.
## **1-е решение: Замена сообщения Object Changed изображением**
Если вам не нравится сообщение **Object Changed**, то вы также можете заменить это сообщение на своё собственное изображение. Вы можете добавить любое желаемое изображение в свою презентацию и затем использовать идентификатор этого добавленного изображения, чтобы заменить сообщение **Object Changed**.

Для достижения этого вы можете добавить несколько строк кода в ваше приложение после добавления **OleObjectFrame** на слайд.
## **Пример**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

После добавления вышеуказанных строк в ваше приложение, результирующий слайд, содержащий **OleObjectFrame**, будет выглядеть так:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**Рисунок**: Сообщение **Object Changed** заменено изображением
## **2-е решение: Создание дополнения для MS PowerPoint**
Вы также можете попробовать создать дополнение для MS PowerPoint, которое обновляет все **OLE objects** при открытии презентации в MS PowerPoint.