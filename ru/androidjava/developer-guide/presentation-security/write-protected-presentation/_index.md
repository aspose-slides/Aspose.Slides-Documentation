---
title: Защита презентаций от записи на Android
linktitle: Защита от записи
type: docs
weight: 25
url: /ru/androidjava/write-protected-presentation/
keywords:
- защита от записи
- защита PowerPoint от записи
- пароль для изменения
- ограничить редактирование презентации
- удалить защиту от записи
- проверка пароля изменения
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Устанавливайте, обнаруживайте, проверяйте и удаляйте пароли защиты от записи в презентациях PowerPoint PPT и PPTX с помощью Aspose.Slides для Android на Java."
---
## **Введение**

Пароль защиты от записи ограничивает изменение презентации, но не шифрует её содержимое. Пользователи могут загрузить и просмотреть защищённую от записи презентацию без пароля. В зависимости от приложения они также могут редактировать содержимое и сохранить его под другим именем, поэтому защита от записи не должна рассматриваться как механизм конфиденциальности.

Пароль открытия служит иной цели: он шифрует презентацию и требуется для загрузки её содержимого. Чтобы зашифровать презентацию или проверить пароль открытия, см. [Password-Protect Presentations](/slides/ru/androidjava/password-protected-presentation/).

Рабочие процессы в этой статье применимы как к презентациям PPT, так и PPTX. Примеры используют файлы PPTX; при сохранении в PPT используйте расширение `.ppt` и соответствующий формат сохранения PPT.

## **Установить защиту от записи в презентации**

Используйте [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) для назначения пароля, ограничивающего изменение презентации. Сохранение презентации сохраняет настройку защиты.

Следующий пример устанавливает защиту от записи в презентацию PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Загрузить защищённую от записи презентацию**

Поскольку защита от записи не шифрует содержимое презентации, пароль не требуется для её загрузки. Пароль имеет значение только при проверке разрешения на изменение защищённой презентации.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Не передавайте пароль защиты от записи в [ILoadOptions.setPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Этот метод принимает пароль открытия для зашифрованного содержимого. Если презентация имеет оба типа защиты, укажите пароль открытия для загрузки и обрабатывайте пароль защиты от записи отдельно.

## **Удалить защиту от записи из презентации**

Используйте [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) для снятия ограничения изменения, затем сохраните презентацию.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Проверить, защищена ли презентация от записи**

Чтобы проверить файл без создания полного экземпляра [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/), вызовите [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) и проверьте [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Метод использует [NullableBool](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/nullablebool/) и возвращает `NullableBool.True`, когда обнаружена защита от записи.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

Перегрузка метода, принимающая поток, [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-), предоставляет ту же информацию для презентации, переданной в виде потока.

## **Проверить пароль защиты от записи**

Используйте [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) для проверки пароля изменения без загрузки полной презентации. Сначала проверьте [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) , чтобы приложение запрашивало или проверяло пароль только при наличии защиты от записи.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) проверяет только пароль защиты от записи. Он не проверяет пароль открытия и не определяет, может ли быть загружено зашифрованное содержимое. Напротив, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) проверяет только пароль открытия. Если полная презентация уже загружена, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) предоставляет эквивалентную проверку через менеджер защиты.

В производственных приложениях не записывайте пароли в журналы и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки и храните пароли в памяти только столько, сколько это необходимо.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/ru/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/ru/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Шифрует ли защита от записи презентацию?**

Нет. Она ограничивает изменение, но оставляет содержимое презентации доступным для загрузки и просмотра.

**Требуется ли пароль защиты от записи для открытия презентации?**

Нет. Только пароль открытия требуется для загрузки зашифрованного содержимого презентации.

**Может ли у презентации быть одновременно пароль открытия и пароль защиты от записи?**

Да. Укажите пароль открытия через параметры загрузки, чтобы открыть зашифрованную презентацию, и проверяйте пароль защиты от записи отдельно, когда требуется авторизация на изменение.