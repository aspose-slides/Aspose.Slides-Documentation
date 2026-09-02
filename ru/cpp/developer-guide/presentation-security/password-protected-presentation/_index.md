---
title: Защита презентаций паролями в C++
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/cpp/password-protected-presentation/
keywords:
- блокировать PowerPoint
- блокировать презентацию
- разблокировать PowerPoint
- разблокировать презентацию
- защитить PowerPoint
- защитить презентацию
- установить пароль
- добавить пароль
- зашифровать PowerPoint
- зашифровать презентацию
- расшифровать PowerPoint
- расшифровать презентацию
- защита от записи
- безопасность PowerPoint
- безопасность презентации
- удалить пароль
- удалить защиту
- удалить шифрование
- отключить пароль
- отключить защиту
- снять защиту от записи
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как легко блокировать и разблокировать презентации PowerPoint и OpenDocument, защищённые паролем, с помощью Aspose.Slides для C++. Обеспечьте безопасность ваших презентаций."
---
## **Введение**

Когда вы защищаете презентацию паролем, вы задаёте пароль, который накладывает определённые ограничения на презентацию. Для снятия ограничений необходимо ввести пароль. Презентация, защищённая паролем, считается заблокированной презентацией.

Обычно вы можете установить пароль, чтобы наложить эти ограничения на презентацию:

- **Изменение**

  Если вы хотите, чтобы только определённые пользователи могли изменять вашу презентацию, вы можете установить ограничение на изменение. Это ограничение препятствует людям изменять, менять или копировать содержимое вашей презентации (если они не предоставят пароль). 

  Однако в этом случае, даже без пароля, пользователь сможет открыть ваш документ. В режиме только для чтения пользователь может просматривать содержимое, включая гиперссылки, анимации, эффекты и прочее, но не может копировать элементы или сохранять презентацию. 

- **Открытие**

  Если вы хотите, чтобы только определённые пользователи могли открыть вашу презентацию, вы можете установить ограничение на открытие. Это ограничение не позволяет людям даже просматривать содержимое вашей презентации (если они не предоставят пароль).

  Технически ограничение на открытие также препятствует пользователям изменять презентацию: если люди не могут открыть презентацию, они не могут её изменять. 
  
  **Примечание** что когда вы защищаете презентацию паролем от открытия, файл презентации шифруется.

## **Как защитить презентацию паролем онлайн**

1. Перейдите на страницу [**Aspose.Slides Lock**](https://products.aspose.app/slides/ru/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Нажмите **Drop or upload your files**.

3. Выберите файл, который хотите защитить паролем, на вашем компьютере. 

4. Введите желаемый пароль для защиты от редактирования; введите желаемый пароль для защиты от просмотра. 

5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательную копию, отметьте флажок **Mark as final**.

6. Нажмите **PROTECT NOW.** 

7. Нажмите **DOWNLOAD NOW.**

## **Защита паролем презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и аналогичные операции для презентаций следующих форматов: 

- PPTX и PPT — Microsoft PowerPoint Presentation 
- ODP — OpenDocument Presentation 
- OTP — OpenDocument Presentation Template 

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем презентаций, чтобы предотвратить изменения следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет выполнять другие задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Дешифрование презентации; открытие зашифрованной презентации
- Удаление шифрования; отключение защиты паролем
- Снятие защиты от записи с презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Зашифровать презентацию**

Вы можете зашифровать презентацию, задав пароль. Затем, чтобы изменить заблокированную презентацию, пользователь должен ввести пароль. 

Чтобы зашифровать или защитить презентацию паролем, необходимо использовать метод encrypt (из [ProtectionManager](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager)) для установки пароля презентации. Вы передаёте пароль в метод encrypt и используете метод save для сохранения зашифрованной презентации. 

Этот пример кода показывает, как зашифровать презентацию:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Установить защиту от записи для презентации** 

Вы можете добавить метку «Do not modify» к презентации. Таким образом, вы сообщаете пользователям, что не хотите, чтобы они вносили изменения в презентацию.  

**Примечание** что процесс защиты от записи не шифрует презентацию. Поэтому пользователи — если они действительно захотят — могут изменять презентацию, но для сохранения изменений им придётся создать презентацию с другим именем. 

Чтобы установить защиту от записи, необходимо использовать метод setWriteProtection. Этот пример кода показывает, как установить защиту от записи для презентации:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Загрузить зашифрованную презентацию**

Aspose.Slides позволяет загрузить зашифрованный файл, передав его пароль. Чтобы дешифровать презентацию, необходимо вызвать метод [RemoveEncryption](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) без параметров. Затем потребуется ввести правильный пароль для загрузки презентации. 

Этот пример кода показывает, как дешифровать презентацию: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// работа с расшифрованной презентацией
```

## **Удалить шифрование из презентации**

Вы можете удалить шифрование или защиту паролем с презентации. Таким образом, пользователи смогут получать доступ к презентации или изменять её без ограничений. 

Чтобы удалить шифрование или защиту паролем, необходимо вызвать метод [RemoveEncryption](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Этот пример кода показывает, как удалить шифрование из презентации:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Удалить защиту от записи из презентации**

Вы можете использовать Aspose.Slides, чтобы снять защиту от записи с файла презентации. Таким образом, пользователи могут изменять её как захотят—и при этом не получают предупреждений. 

Вы можете снять защиту от записи с презентации, используя метод [RemoveWriteProtection](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Этот пример кода показывает, как снять защиту от записи с презентации:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Получить свойства зашифрованной презентации**

Обычно пользователи испытывают трудности с получением свойств документа зашифрованной или защищённой паролем презентации. Тем не менее, Aspose.Slides предоставляет механизм, позволяющий защитить презентацию паролем, одновременно обеспечивая доступ к её свойствам документа.

**Примечание:** По умолчанию, когда Aspose.Slides шифрует презентацию, свойства её документа также защищаются паролем. Если необходимо, чтобы свойства документа были доступны даже после шифрования, Aspose.Slides позволяет именно это сделать.

Если вы хотите, чтобы пользователи сохраняли возможность доступа к свойствам зашифрованной презентации, передайте `false` методу `set_EncryptDocumentProperties` интерфейса [IProtectionManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/). Этот пример кода показывает, как зашифровать презентацию, при этом предоставив пользователям доступ к её свойствам документа:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Загрузить только свойства документа из зашифрованной презентации**

Чтобы просмотреть метаданные зашифрованной презентации без загрузки её слайдов или другого содержимого, создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/) и установите [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) в `true`. В этом режиме Aspose.Slides игнорирует пароль и загружает только свойства документа, которые находятся в публичном доступе.

Следующий пример кода считывает встроенные и пользовательские свойства документа через [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Этот процесс работает только тогда, когда свойства документа оставлены незашифрованными (публичными) при шифровании презентации. Если свойства документа зашифрованы, установка `LoadOptions::set_OnlyLoadDocumentProperties` в `true` вызывает исключение, поскольку пароль в этом режиме игнорируется. Чтобы получить доступ к зашифрованным свойствам документа или загрузить полную презентацию, включая слайды и другое содержимое, укажите правильный пароль с помощью `LoadOptions::set_Password` в [LoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/).

## **Проверить, защищена ли презентация паролем**

Прежде чем загружать презентацию, вы можете захотеть проверить и убедиться, что презентация не защищена паролем. Таким образом, вы избегаете ошибок и подобных проблем, возникающих при попытке загрузить защищённую паролем презентацию без пароля.

Этот код C++ показывает, как проверить презентацию на наличие защиты паролем (не загружая саму презентацию):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Проверить, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Для этого можно использовать метод [get_IsEncrypted()](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), который возвращает `true`, если презентация зашифрована, и `false`, если нет. 

Этот пример кода показывает, как проверить, зашифрована ли презентация:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Проверить, защищена ли презентация от записи**

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Для этого можно использовать метод [get_IsWriteProtected()](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), который возвращает `true`, если презентация зашифрована, и `false`, если нет. 

Этот пример кода показывает, как проверить, защищена ли презентация от записи:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Проверить использование пароля в презентации**

Возможно, вы захотите проверить и убедиться, что конкретный пароль был использован для защиты документа презентации. Aspose.Slides предоставляет средства для проверки пароля. 

Этот пример кода показывает, как проверить пароль:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// проверить, совпадает ли пароль
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Он возвращает `true`, если презентация зашифрована указанным паролем. В противном случае возвращает `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ru/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Какие методы шифрования поддерживает Aspose.Slides?**

Aspose.Slides поддерживает современные методы шифрования, включая алгоритмы на основе AES, обеспечивая высокий уровень защиты данных ваших презентаций.

**Что происходит, если при попытке открыть презентацию введён неверный пароль?**

Если введён неверный пароль, генерируется исключение, сообщающее о том, что доступ к презентации запрещён. Это помогает предотвратить несанкционированный доступ и защищает содержимое презентации.

**Есть ли какие‑то последствия для производительности при работе с защищёнными паролем презентациями?**

Процессы шифрования и дешифрования могут вызвать небольшие задержки при открытии и сохранении. В большинстве случаев влияние на производительность минимально и не оказывает существенного влияния на общее время обработки ваших задач с презентациями.