---
title: Управление BLOB
type: docs
weight: 10
url: /ru/net/manage-blob/
keywords: "Добавить blob, Экспортировать blob, Добавить изображение как blob, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте blob в презентацию PowerPoint на C# или .NET. Экспортируйте blob. Добавьте изображение как blob."
---

## **О BLOB**

**BLOB** (**Binary Large Object**) – это обычно крупный объект (фото, презентация, документ или медиа), хранящийся в бинарных форматах.

Aspose.Slides для .NET позволяет использовать BLOB для объектов таким образом, чтобы уменьшить потребление памяти при работе с большими файлами.

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/net/) для .NET позволяет добавлять большие файлы (в данном случае, большой видеофайл) через процесс, связанный с BLOB, для снижения потребления памяти.

Следующий код на C# показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создает новую презентацию, в которую будет добавлено видео
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Добавляем видео в презентацию - выбираем поведение KeepLocked, потому что не намерены
        // обращаться к файлу "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Хотя большая презентация выводится, потребление памяти
        // остается низким на протяжении всего жизненного цикла объекта pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Экспорт большого файла через BLOB из презентации**
Aspose.Slides для .NET позволяет экспортировать большие файлы (в данном случае, аудио или видеофайл) через процесс, связанный с BLOB, из презентаций. Например, вам может понадобиться извлечь большой медиафайл из презентации, но вы не хотите, чтобы файл загружался в память вашего компьютера. Экспортируя файл через процесс BLOB, вы можете поддерживать низкое потребление памяти.

Следующий код на C# демонстрирует описанную операцию:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Блокирует исходный файл и НЕ загружает его в память
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Создание экземпляра Presentation, блокируя файл "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Сохраняем каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использоваться
	// для передачи данных из видеопотока презентации в поток для вновь созданного видеофайла.
	byte[] buffer = new byte[8 * 1024];

	// Перебираем видео
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Открываем поток видео презентации. Обратите внимание, что мы намеренно избегали доступа к свойствам
		// таким как video.BinaryData - потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
		// приводит к загрузке байтов в память. Мы используем video.GetStream, который вернет Stream - и не требует
		//  загрузки всего видео в память.
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

	// При необходимости вы можете применить аналогичные шаги для аудиофайлов. 
}
```

### **Добавление изображения как BLOB в презентацию**
С помощью методов из интерфейса [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Следующий код на C# показывает, как добавить большое изображение через процесс BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// Создает новую презентацию, в которую будет добавлено изображение.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Добавляем изображение в презентацию - выбираем поведение KeepLocked, потому что не намерены
		// обращаться к файлу "largeImage.png".
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Хотя большая презентация выводится, потребление памяти 
		// остается низким на протяжении всего жизненного цикла объекта pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Память и большие презентации**

Как правило, для загрузки большой презентации компьютерам требуется много временной памяти. Все содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестает использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), которая содержит видеофайл объемом 1,5 ГБ. Стандартный метод загрузки презентации описан в следующем коде на C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Но этот метод потребляет около 1,6 ГБ временной памяти.

### **Загрузка большой презентации как BLOB**

С помощью процесса, связанного с BLOB, вы можете загрузить большую презентацию, используя мало памяти. Этот код на C# описывает реализацию, где для загрузки большого файла презентации (large.pptx) используется процесс BLOB:

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

Когда используется процесс BLOB, ваш компьютер создает временные файлы в папке по умолчанию для временных файлов. Если вы хотите, чтобы временные файлы хранились в другой папке, вы можете изменить параметры хранилища, используя `TempFilesRootPath`:

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

{{% alert title="Информация" color="info" %}}

При использовании `TempFilesRootPath` Aspose.Slides не создает автоматически папку для хранения временных файлов. Вам нужно создать папку вручную.

{{% /alert %}}