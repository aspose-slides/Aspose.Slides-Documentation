---
title: Управление BLOB
type: docs
weight: 10
url: /ru/net/manage-blob/
keywords: "Добавить BLOB, Экспортировать BLOB, Добавить изображение как BLOB, Презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Добавить BLOB в презентацию PowerPoint на C# или .NET. Экспортировать BLOB. Добавить изображение как BLOB"
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фотография, презентация, документ или медиа), сохранённый в двоичном формате. 

Aspose.Slides for .NET позволяет использовать BLOB‑объекты для объектов способом, уменьшающим потребление памяти при работе с большими файлами. 

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/net/) for .NET позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, использующий BLOB, чтобы снизить потребление памяти.

Этот пример на C# показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создаёт новую презентацию, в которую будет добавлено видео
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что мы
        //не планируем получать доступ к файлу "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        // остается низким в течение жизненного цикла объекта pres
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Экспорт большого файла через BLOB из презентации**
Aspose.Slides for .NET позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) через процесс, использующий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиафайл из презентации, но не загружать его в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти. 

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

// Создаёт экземпляр Presentation, блокирует файл "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Сохраним каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использоваться
	// для передачи данных из видеопотока презентации в поток только что созданного видеофайла.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Открывает видеопоток презентации. Обратите внимание, что мы намеренно воздержались от доступа к свойствам
		// таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, которое затем
		// заставляет байты загружаться в память. Мы используем video.GetStream, который возвращает Stream — и НЕ
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

	// При необходимости вы можете применить те же шаги к аудиофайлам. 
}
```


### **Добавление изображения как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) и класса [**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) вы можете добавить крупное изображение в виде потока, чтобы оно обрабатывалось как BLOB. 

Этот пример кода на C# показывает, как добавить большое изображение через процесс BLOB:
```c#
string pathToLargeImage = "large_image.jpg";

// создаёт новую презентацию, в которую будет добавлено изображение.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Добавим изображение в презентацию - мы выбираем поведение KeepLocked, потому что мы
		// НЕ планируем обращаться к файлу "largeImage.png".
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти 
		// остаётся низким в течение жизненного цикла объекта pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **Память и большие презентации**

Как правило, для загрузки большой презентации компьютерам требуется большое количество временной памяти. Всё содержимое презентации загружается в память, и файл (из которого была загружена презентация) больше не используется. 

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде на C#:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


Но этот метод потребляет около 1,6 ГБ временной памяти. 

### **Загрузка большой презентации как BLOB**

С помощью процесса, использующего BLOB, вы можете загрузить большую презентацию, используя мало памяти. Этот код на C# описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
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

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, вы можете изменить настройки хранилища, используя `TempFilesRootPath`:
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

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**

Крупные двоичные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Весь файл презентации также обрабатывается как BLOB при загрузке или сохранении. Эти объекты управляются политиками BLOB, которые позволяют контролировать использование памяти и при необходимости выгружать данные во временные файлы.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). Здесь задаётся ограничение памяти для BLOB, разрешение или запрет временных файлов, путь к корневой папке для временных файлов и режим блокировки источника.

**Влияют ли настройки BLOB на производительность, и как сбалансировать скорость и потребление памяти?**

Да. Хранение BLOB в памяти максимизирует скорость, но повышает потребление ОЗУ; снижение лимита памяти переносит часть работы во временные файлы, уменьшая ОЗУ, но увеличивая ввод‑вывод. Настройте порог [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/), чтобы достичь оптимального баланса для вашей нагрузки и среды.

**Помогают ли параметры BLOB при открытии экстремально больших презентаций (например, в гигабайтах)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника может существенно снизить пиковое использование ОЗУ и стабилизировать обработку очень больших презентаций.

**Могу ли я использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть входным потоком и блокировать его (в зависимости от выбранного режима блокировки), а временные файлы используются при разрешении, обеспечивая предсказуемое использование памяти во время обработки.