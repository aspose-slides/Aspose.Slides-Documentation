---
title: Управление BLOB
type: docs
weight: 10
url: /cpp/manage-blob/
keywords: "Добавить blob, Экспортировать blob, Добавить изображение как blob, Презентация PowerPoint, C++, Aspose.Slides для C++"
description: "Добавить blob в презентацию PowerPoint на C++. Экспортировать blob. Добавить изображение как blob"
---

## **О BLOB**

**BLOB** (**Бинарный большой объект**) обычно представляет собой крупный элемент (фото, презентация, документ или медиа), сохранённый в бинарном формате. 

Aspose.Slides для C++ позволяет вам использовать BLOB для объектов таким образом, чтобы снизить потребление памяти при работе с большими файлами. 

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/cpp/) для C++ позволяет добавлять большие файлы (в данном случае, большой видеофайл) через процесс, связанный с BLOB, чтобы снизить потребление памяти.

Этот код на C++ показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Создаёт новую презентацию, в которую будет добавлено видео
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Давайте добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что мы не
// собираемся получать доступ к файлу "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Сохраняет презентацию. Когда большая презентация сохраняется, потребление памяти 
// остаётся низким на протяжении всего жизненного цикла объекта pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **Экспорт большого файла через BLOB из презентации**

Aspose.Slides для C++ позволяет экспортировать большие файлы (в данном случае, аудио- или видеофайл) через процесс, связанный с BLOB, из презентаций. Например, вам может понадобиться извлечь большой медиафайл из презентации, но вы не хотите, чтобы файл загружался в память вашего компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код на C++ демонстрирует описанную операцию:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Создаёт экземпляр презентации, блокирует файл "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Давайте сохраним каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер,
// который будет использоваться для передачи данных из видеопотока презентации в поток для вновь созданного видеофайла.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Итерирует по видео
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегали доступа к методам
	// таким как video->get_BinaryData - потому что этот метод возвращает массив байтов, содержащий полное видео, что затем
	// приводит к загрузке байтов в память. Мы используем video->GetStream, который вернет Stream - и это НИ
	// требует загрузки всего видео в память.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Потребление памяти останется низким, независимо от размера видео или презентации,
}

// При необходимости, вы можете применить те же шаги для аудиофайлов.
```

### **Добавление изображения как BLOB в презентацию**

С помощью методов из интерфейса [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) и класса [**ImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот код на C++ показывает, как добавить большое изображение через процесс BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// Создаёт новую презентацию, в которую будет добавлено изображение.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Давайте добавим изображение в презентацию - мы выбираем поведение KeepLocked, потому что мы не
// собираемся получать доступ к файлу "largeImage.png".
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Сохраняет презентацию. Когда большая презентация сохраняется, потребление памяти 
// остаётся низким на протяжении всего жизненного цикла объекта pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Память и большие презентации**

Как правило, для загрузки большой презентации компьютеры требуют много временной памяти. Всё содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестаёт использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), которая содержит видеофайл объёмом 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде на C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Но этот метод потребляет около 1,6 ГБ временной памяти. 

### **Загрузка большой презентации как BLOB**

С помощью процесса, связанного с BLOB, вы можете загрузить большую презентацию, используя немного памяти. Этот код на C++ описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Изменение папки для временных файлов**

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите, чтобы временные файлы сохранялись в другой папке, вы можете изменить настройки хранения с помощью `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Информация" color="info" %}}

Когда вы используете `TempFilesRootPath`, Aspose.Slides не создаёт автоматически папку для хранения временных файлов. Вам нужно создать папку вручную. 

{{% /alert %}}