---
title: Управление BLOB в презентациях .NET для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для .NET, оптимизируя операции с файлами PowerPoint и OpenDocument для эффективной работы с презентациями."
---
## **Обзор**

Aspose.Slides предоставляет обработку на основе BLOB для крупных бинарных данных в презентациях, что помогает уменьшить расход памяти при работе с большими изображениями, аудио, видео и файлами презентаций.

Эта статья показывает, как использовать обработку на основе BLOB для добавления крупного медиафайла в презентацию, экспорта крупного медиафайла из презентации и более эффективной загрузки больших презентаций. Также объясняется, как временные файлы могут использоваться во время обработки и как изменить папку, в которой они хранятся.

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохранённый в бинарном формате. 

Aspose.Slides for .NET позволяет использовать BLOB для объектов таким образом, который уменьшает расход памяти при работе с большими файлами. 

## **Использование BLOB для снижения расхода памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/net/) для .NET позволяет добавлять крупные файлы (в данном случае большой видеофайл) через процесс, использующий BLOB, чтобы снизить расход памяти.

Этот пример на C# показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создаёт новую презентацию, к которой будет добавлено видео
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
        // не планируем обращаться к файлу "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Пока выводится крупная презентация, потребление памяти
        // остается низким на протяжении жизненного цикла объекта pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Экспорт большого файла через BLOB из презентации**
Aspose.Slides for .NET позволяет экспортировать крупные файлы (в данном случае аудио или видео) через процесс, использующий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиафайл из презентации, но не загружать его в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти. 

Этот код на C# демонстрирует описанную операцию:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Блокирует исходный файл и НЕ загружает его в память
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Создаёт экземпляр Presentation и блокирует файл "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Сохраним каждое видео в файл. Чтобы избежать высокого скачка памяти, нам нужен буфер, который будет использован
	// для передачи данных из видеопотока презентации в поток только что созданного видеофайла.
	byte[] buffer = new byte[8 * 1024];

	// Перебирает видеоматериалы
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Открывает видеопоток презентации. Обратите внимание, что мы умышленно избегали доступа к свойствам
		// таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, которое затем
		// заставляет байты загружаться в память. Мы используем video.GetStream, который возвращает Stream и НЕ
		//  требует загрузки всего видео в память.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// Потребление памяти останется низким независимо от размера видео или презентации,
	}

	// При необходимости вы можете выполнить те же шаги для аудиофайлов. 
}
```

### **Добавление изображения как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/ru/net/aspose.slides/iimagecollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/ru/net/aspose.slides/imagecollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB. 

Этот код на C# показывает, как добавить большое изображение через процесс BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// Создаёт новую презентацию, к которой будет добавлено изображение.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что мы
		// НЕ намерены обращаться к файлу "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока выводится крупная презентация, потребление памяти 
		// остаётся низким на протяжении жизненного цикла объекта pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Память и крупные презентации**

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестаёт использоваться. 

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде на C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Но этот метод потребляет около 1,6 ГБ временной памяти. 

### **Загрузка большой презентации как BLOB**

Через процесс, использующий BLOB, вы можете загрузить большую презентацию, используя минимум памяти. Этот код на C# описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Изменение папки для временных файлов**

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, можно изменить настройки хранилища, используя `TempFilesRootPath`:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
При использовании `TempFilesRootPath` Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Вы должны создать папку вручную. 
{{% /alert %}}

### **Освобождение объектов Presentation для высвобождения памяти**

При обработке крупных презентаций убедитесь, что экземпляр [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) правильно освобождается, чтобы освободить занятую им память. Рекомендуемый способ – использовать оператор `using` или объявление, как показано в примерах выше; он автоматически освобождает презентацию и неуправляемые ресурсы при выходе из блока.

Если вы создаёте презентацию без блока `using`, явно вызовите `Dispose()` после завершения работы с ней.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...обработать презентацию...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Явно освобождаем ресурсы.
presentation.Dispose();
```

## **Вопросы и ответы**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и контролируются параметрами BLOB?**

Крупные бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также попадает под обработку BLOB при загрузке или сохранении. Эти объекты управляются политиками BLOB, позволяющими контролировать использование памяти и запись во временные файлы при необходимости.

**Где настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/) с [BlobManagementOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/blobmanagementoptions/). Там задаётся лимит памяти для BLOB, разрешение или запрет временных файлов, корневой путь для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти максимизирует скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переводит больше работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Настройте порог [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/ru/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) для достижения нужного баланса под вашу нагрузку и среду.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, в гигабайтах)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут существенно снизить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, когда это разрешено, обеспечивая предсказуемое использование памяти во время обработки.