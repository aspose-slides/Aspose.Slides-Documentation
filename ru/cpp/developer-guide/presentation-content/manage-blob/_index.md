---
title: Управление BLOB в презентациях на C++ для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/cpp/manage-blob/
keywords:
- большой объект
- большой элемент
- большой файл
- добавить BLOB
- экспортировать BLOB
- добавить изображение как BLOB
- сократить память
- потребление памяти
- большая презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для C++, чтобы упростить операции с файлами PowerPoint и OpenDocument и обеспечить эффективную работу с презентациями."
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохранённый в бинарных форматах. 

Aspose.Slides for C++ позволяет использовать BLOB для объектов таким образом, чтобы уменьшить потребление памяти при работе с крупными файлами. 

## **Используйте BLOB для уменьшения потребления памяти**

### **Добавить большой файл через BLOB в презентацию**

[Aspose.Slides](/slides/ru/cpp/) for C++ позволяет добавить крупные файлы (в данном случае большой видеофайл) через процесс, использующий BLOB, чтобы уменьшить потребление памяти.

Этот код C++ показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Создаёт новую презентацию, в которую будет добавлено видео
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что мы
// не планируем получать доступ к файлу "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
// остается низким в течение жизненного цикла объекта pres
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```



### **Экспортировать большой файл через BLOB из презентации**
Aspose.Slides for C++ позволяет экспортировать крупные файлы (в данном случае аудио‑ или видеофайл) через процесс, использующий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиафайл из презентации, но вы не хотите, чтобы файл загружался в память компьютера. При экспорте файла через процесс BLOB вы сохраняете низкое потребление памяти. 

Этот код C++ демонстрирует описанную операцию:
```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Создаёт экземпляр Presentation и блокирует файл "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Сохраним каждое видео в файл. Чтобы предотвратить высокое использование памяти, нам нужен буфер, который будет использоваться
// для передачи данных из видеопотока презентации в поток только что созданного видеофайла.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Итерируется по видеоматериалам
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегали обращения к методам
	// например video->get_BinaryData - потому что этот метод возвращает массив байтов, содержащий полное видео, что затем
	// вызывает загрузку байтов в память. Мы используем video->GetStream, который возвращает Stream и НЕ
	// требует от нас загрузки всего видео в память.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Потребление памяти останется низким независимо от размера видео или презентации,
}

// При необходимости вы можете применить те же шаги к аудиофайлам.
```



### **Добавить изображение как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) и класса [**ImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB. 

Этот код C++ показывает, как добавить большое изображение через процесс BLOB:
```cpp
const String pathToLargeImage = u"large_image.jpg";

// создает новую презентацию, в которую будет добавлено изображение.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Добавим изображение в презентацию - мы выбираем поведение KeepLocked, потому что мы
// НЕ планируем обращаться к файлу "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти 
// остается низким в течение жизненного цикла объекта pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```


## **Память и крупные презентации**

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, а файл (из которого была загружена презентация) перестаёт использоваться. 

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую 1,5 ГБ видеофайл. Стандартный метод загрузки презентации показан в этом коде C++:
```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


Но этот метод потребляет около 1,6 ГБ временной памяти. 

### **Загрузить большую презентацию как BLOB**

Через процесс, использующий BLOB, вы можете загрузить большую презентацию, используя мало памяти. Этот код C++ описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


#### **Изменить папку для временных файлов**

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, можно изменить настройки хранилища с помощью `TempFilesRootPath`:
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```


{{% alert title="Info" color="info" %}}
При использовании `TempFilesRootPath` Aspose.Slides не создаёт автоматически папку для временных файлов. Вам необходимо создать папку вручную. 
{{% /alert %}}

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и контролируются параметрами BLOB?**

Крупные бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также участвует в обработке BLOB при загрузке или сохранении. На эти объекты распространяются политики BLOB, позволяющие управлять использованием памяти и переходом к временным файлам при необходимости.

**Где я могу настроить правила обработки BLOB во время загрузки презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/). Здесь задаётся предел объёма BLOB в памяти, разрешение или запрет временных файлов, корневой путь для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как найти баланс между скоростью и памятью?**

Да. Хранение BLOB в памяти повышает скорость, но увеличивает использование ОЗУ; снижение предела памяти переносит больше работы во временные файлы, снижая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) для выбора оптимального баланса под вашу нагрузку и окружение.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника может значительно снизить пиковое использование ОЗУ и стабилизировать процесс обработки очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применяются к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, обеспечивая предсказуемое использование памяти во время обработки.