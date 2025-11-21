---
title: Управление BLOB-объектами презентаций в .NET для эффективного использования памяти
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
- сократить использование памяти
- потребление памяти
- большая презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для .NET, чтобы упростить работу с файлами PowerPoint и OpenDocument и обеспечить эффективную обработку презентаций."
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохранённый в бинарных форматах. 

Aspose.Slides для .NET позволяет использовать BLOB‑ы для объектов таким образом, чтобы уменьшить потребление памяти при работе с большими файлами. 

## **Использование BLOB для уменьшения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/net/) для .NET позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, включающий BLOB‑ы, чтобы уменьшить потребление памяти.

Этот пример C# показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создает новую презентацию, в которую будет добавлено видео
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Давайте добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что мы
        //не планируем обращаться к файлу "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        //остается низким на протяжении жизненного цикла объекта pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Экспорт большого файла через BLOB из презентации**
Aspose.Slides для .NET позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) через процесс, включающий BLOB‑ы, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но не загружать файл в память компьютера. При экспорте файла через процесс BLOB вы сохраняете низкое потребление памяти. 

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
	// Давайте сохраним каждое видео в файл. Чтобы предотвратить высокое использование памяти, нам нужен буфер, который будет использоваться
	// для передачи данных из видеопотока презентации в поток нового видеофайла.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Открывает видеопоток презентации. Обратите внимание, что мы специально избегаем доступа к свойствам
		// таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, которое затем
		// приводит к загрузке байтов в память. Мы используем video.GetStream, который возвращает Stream — и НЕ
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

	// При необходимости можно применить те же шаги для аудиофайлов. 
}
```


### **Добавление изображения как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB. 

Этот код на C# показывает, как добавить большое изображение через процесс BLOB:
```c#
string pathToLargeImage = "large_image.jpg";

// создает новую презентацию, в которую будет добавлено изображение.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Добавим изображение в презентацию - мы выбираем поведение KeepLocked, потому что
		// НЕ планируем обращаться к файлу "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти 
		// остается низким на протяжении жизненного цикла объекта pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **Память и большие презентации**

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, а файл (из которого была загружена презентация) перестаёт использоваться. 

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде C#:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


Однако этот метод потребляет около 1,6 ГБ временной памяти. 

### **Загрузка большой презентации как BLOB**

Через процесс, включающий BLOB, вы можете загрузить большую презентацию, используя мало памяти. Этот код C# описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
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

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите, чтобы временные файлы хранились в другой папке, вы можете изменить настройки хранилища, используя `TempFilesRootPath`:
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
При использовании `TempFilesRootPath` Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Вам необходимо создать папку вручную. 
{{% /alert %}}

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**

Большие бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. При загрузке или сохранении также обрабатывается весь файл презентации как BLOB. Эти объекты управляются политиками BLOB, позволяющими контролировать использование памяти и переключаться на временные файлы при необходимости. 

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). Здесь вы задаёте ограничение памяти для BLOB, разрешаете или запрещаете временные файлы, выбираете корневой путь для временных файлов и задаёте поведение блокировки источника. 

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти обеспечивает максимальную скорость, но увеличивает потребление ОЗУ; уменьшение лимита памяти переводит большую часть работы во временные файлы, снижая ОЗУ за счёт дополнительного ввода‑вывода. Настройте порог [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/), чтобы достичь оптимального баланса для вашей нагрузки и среды. 

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут существенно снизить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов. 

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применяются к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, поддерживая предсказуемое потребление памяти во время обработки.