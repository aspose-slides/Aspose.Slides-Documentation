---
title: Проблема изменения объекта при добавлении OleObjectFrame
type: docs
weight: 10
url: /ru/php-java/object-changed-issue-when-adding-oleobjectframe/
---

## **Заявление о проблеме**
Когда разработчики добавляют **OleObjectFrame** на свои слайды с помощью Aspose.Slides для PHP через Java, на выходном слайде вместо **OLE Object** отображается сообщение **Object Changed**. Большинство клиентов Aspose.Slides для PHP через Java считает, что это ошибка или баг в Aspose.Slides для PHP через Java.
## **Критический анализ и объяснение**
Прежде всего, важно знать, что сообщение **Object Changed**, отображаемое Aspose.Slides для PHP через Java после добавления **OleObjectFrame** на слайд, **НЕ** является ошибкой или багом в Aspose.Slides для PHP через Java. Это просто информация или сообщение, уведомляющее пользователей о том, что объект изменен и изображение должно быть обновлено.

Например, если вы добавите **Microsoft Excel Chart** как **OleObjectFrame** на свой слайд (для получения дополнительных деталей и кода о том, как добавить **OleObjectFrame** на ваш слайд, [нажмите здесь](/slides/ru/php-java/adding-frame-to-the-slide/)), а затем откроете файл презентации с помощью MS PowerPoint, то слайд (на который был добавлен **OLE Object**) будет выглядеть следующим образом:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**Рисунок**: Слайд с сообщением **Object Changed** после добавления **OLE Object**

Это не ошибка, и ваш OLE Object все еще добавлен на слайд. Если вы хотите это проверить, то **Дважды щелкните** на сообщении **Object Changed** или **Щелкните правой кнопкой мыши** на нем и выберите опцию **Worksheet Object -> Edit**, как показано ниже на рисунке:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**Рисунок**: Выбор опции **Edit** для редактирования **OLE Object**

После того, как вы выберете опцию **Edit** из всплывающего меню, вы увидите, что **Embedded OLE Object** станет видимым в редактируемом виде, как показано ниже:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**Рисунок**: **OLE Object** в редактируемой форме

Вы все еще можете видеть сообщение **Object Changed** на слайде в **Левой панели** MS PowerPoint, показывающей предварительный просмотр слайдов. Как только вы щелкнете на **OLE Object**, вы увидите, что предварительный просмотр слайда также изменится, и сообщение **Changed Object** будет заменено изображением **OLE Object**, как показано ниже:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**Рисунок**: Обновление изображения **OLE Object**

Теперь вы должны **Сохранить** свой файл презентации с помощью MS PowerPoint, чтобы изображение **OLE Object** обновилось. После того, как вы сохраните свою презентацию и снова откроете ее с помощью MS PowerPoint, вы увидите, что сообщение **Object Changed** больше не будет присутствовать.
## **Другие решения**
В приведенном выше критическом анализе мы продемонстрировали, что изображение **OLE Object** можно обновить, открыв файл презентации в MS PowerPoint и затем сохранив его. Но есть еще два решения для работы с сообщением **Object Changed**.
## **1-е решение: Замена сообщения Object Changed изображением**
Если вам не нравится сообщение **Object Changed**, то вы можете заменить это сообщение на свое изображение. Вы можете добавить любое желаемое изображение в вашу презентацию и затем использовать идентификатор этого добавленного изображения, чтобы заменить сообщение **Object Changed**.

Чтобы достичь этого, вы можете добавить этот небольшой фрагмент кода в ваше приложение после добавления **OleObjectFrame** на ваш слайд.
## **Пример**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

После добавления приведенных выше строк в ваше приложение полученный слайд, содержащий **OleObjectFrame**, будет выглядеть следующим образом:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**Рисунок**: Сообщение **Object Changed** заменено изображением
## **2-е решение: Создание дополнения для MS PowerPoint**
Вы также можете попробовать создать дополнение для MS PowerPoint, которое обновляет все **OLE объекты**, когда вы открываете презентацию в MS PowerPoint.