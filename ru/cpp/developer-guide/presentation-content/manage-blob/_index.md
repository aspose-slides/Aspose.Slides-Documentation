---
title: Управление BLOB презентаций в C++ для эффективного использования памяти
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
- уменьшить память
- потребление памяти
- большая презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для C++, чтобы упростить операции с файлами PowerPoint и OpenDocument для эффективной обработки презентаций."
---
## **Обзор**

Aspose.Slides предоставляет обработку на основе BLOB для больших двоичных данных в презентациях, помогая уменьшить потребление памяти при работе с большими изображениями, аудио, видео и файлами презентаций.

В этой статье показано, как использовать обработку на основе BLOB для добавления больших медиафайлов в презентацию, экспорта больших медиафайлов из презентации и более эффективной загрузки больших презентаций. Также объясняется, как во время обработки можно использовать временные файлы и как изменить папку, используемую для их хранения.

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой элемент (фото, презентацию, документ или медиа), сохранённый в двоичном формате.

Aspose.Slides for C++ позволяет использовать BLOB для объектов таким образом, который снижает потребление памяти при работе с большими файлами.

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/cpp/) for C++ позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, использующий BLOB, чтобы уменьшить потребление памяти.

Этот C++‑код показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Создаёт новую презентацию, в которую будет добавлено видео
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Давайте добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
// не планируем обращаться к файлу "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
// остается низким на протяжении жизненного цикла объекта pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Экспорт большого файла через BLOB из презентации**
Aspose.Slides for C++ позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) через процесс, использующий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиафайл из презентации, но не загружать его в оперативную память компьютера. При экспорте файла через процесс BLOB потребление памяти остаётся низким.

Этот код на C++ демонстрирует описанную операцию:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Создаёт экземпляр Presentation и блокирует файл "hugePresentationWithAudiosAndVideos.pptx".
auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Сохраним каждое видео в файл. Чтобы предотвратить высокое использование памяти, нам нужен буфер, который будет использован
// для передачи данных из видеопотока презентации в поток нового видеофайла.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Открывает видеопоток презентации. Обратите внимание, что мы сознательно избегали обращения к методам
	// таким как video->get_BinaryData — потому что этот метод возвращает массив байтов, содержащий полное видео, что затем
	// загружает байты в память. Мы используем video->GetStream, который возвращает Stream — и НЕ
	// требует загрузки всего видео в память.
	
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

### **Добавление изображения как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_image_collection) и класса [**ImageCollection** ](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.image_collection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот C++‑код показывает, как добавить большое изображение через процесс BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// создает новую презентацию, в которую будет добавлено изображение.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что мы
// НЕ планируем обращаться к файлу "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти 
// остается низким на протяжении жизненного цикла объекта pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Память и большие презентации**

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, и файл, из которого была загружена презентация, перестаёт использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл объёмом 1,5 ГБ. Стандартный метод загрузки презентации описан в этом C++‑коде:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Но этот метод потребляет около 1,6 ГБ временной памяти.

### **Загрузка большой презентации как BLOB**

Через процесс, использующий BLOB, можно загрузить большую презентацию, используя минимум памяти. Этот C++‑код описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

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

При использовании процесса BLOB ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите, чтобы временные файлы хранились в другой папке, можно изменить настройки хранилища с помощью `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Когда вы используете `TempFilesRootPath`, Aspose.Slides не создаёт автоматически папку для хранения временных файлов. Папку необходимо создать вручную.
{{% /alert %}}

### **Освобождение объектов презентации для высвобождения памяти**

При обработке больших презентаций убедитесь, что экземпляр [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) правильно освобождается, чтобы освободить занятые им ресурсы памяти. Вызовите `Dispose()` после завершения работы с презентацией, чтобы освободить неуправляемые ресурсы.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...обработать презентацию...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Явно освобождаем ресурсы.
presentation->Dispose();
```

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и контролируются параметрами BLOB?**

Большие двоичные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также участвует в обработке BLOB при загрузке или сохранении. На эти объекты действуют политики BLOB, позволяющие управлять использованием памяти и записью во временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/) с [BlobManagementOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/blobmanagementoptions/). Там задаётся лимит памяти для BLOB, разрешение или запрет временных файлов, корневой путь для временных файлов и поведение блокировки источника.

**Влияют ли параметры BLOB на производительность, и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти максимизирует скорость, но увеличивает расход ОЗУ; снижение лимита памяти переносит часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/ru/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) для нахождения оптимального баланса под вашу нагрузку и окружение.

**Помогают ли параметры BLOB при открытии крайне больших презентаций (например, гигабайтных)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника может значительно снизить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков, а не из файлов на диске?**

Да. Те же правила применяются к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, что обеспечивает предсказуемое потребление памяти во время обработки.