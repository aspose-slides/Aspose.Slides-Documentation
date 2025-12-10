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
description: "Управляйте данными BLOB в Aspose.Slides для .NET, упрощая работу с файлами PowerPoint и OpenDocument для эффективного управления презентациями."
---

## **Об BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой элемент (фото, презентацию, документ или медиа), сохранённый в бинарных форматах. 

Aspose.Slides for .NET позволяет использовать BLOB‑объекты так, чтобы уменьшить потребление памяти при работе с большими файлами. 

## **Используйте BLOB для уменьшения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/net/) for .NET позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс с использованием BLOB‑ов, чтобы уменьшить потребление памяти.

Этот пример C# показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создаёт новую презентацию, в которую будет добавлено видео
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
        //не планируем обращаться к файлу "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Пока большая презентация выводится, потребление памяти
        // остается низким на протяжении жизненного цикла объекта pres.
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```



### **Экспорт большого файла через BLOB из презентации**
Aspose.Slides for .NET позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) через процесс, включающий BLOB‑ы, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но не загружать его в оперативную память компьютера. Экспортируя файл через процесс BLOB, вы удерживаете потребление памяти на низком уровне. 

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
	// Сохраним каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использоваться
	// для передачи данных из видеопотока презентации в поток нового создаваемого видеофайла.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегаем доступа к свойствам
		// таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
		// вызывает загрузку байтов в память. Мы используем video.GetStream, который возвращает Stream и НЕ
		//  требует от нас загружать всё видео в память.
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

	// При необходимости можно выполнить те же шаги для аудиофайлов. 
}
```


### **Добавление изображения как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB. 

Этот код C# показывает, как добавить большое изображение через процесс BLOB:
```c#
string pathToLargeImage = "large_image.jpg";

// создаёт новую презентацию, в которую будет добавлено изображение.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Давайте добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что мы
		// НЕ собираемся обращаться к файлу "largeImage.png".
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока создаётся большая презентация, потребление памяти 
		// остаётся низким на протяжении жизненного цикла объекта pres.
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **Память и большие презентации**

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Весь контент презентации загружается в оперативную память, а файл (из которого была загружена презентация) перестаёт использоваться. 

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде C#:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


Но этот метод потребляет около 1,6 ГБ временной памяти. 

### **Загрузка большой презентации как BLOB**

Через процесс, включающий BLOB, вы можете загрузить большую презентацию, используя минимум памяти. Этот код C# описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
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


### **Изменить папку для временных файлов**

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите сохранять временные файлы в другой папке, можно изменить настройки хранилища, используя `TempFilesRootPath`:
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

При использовании `TempFilesRootPath` Aspose.Slides не создаёт папку для временных файлов автоматически. Папку необходимо создать вручную. 

{{% /alert %}}

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**

Большие бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также участвует в обработке BLOB при загрузке или сохранении. Эти объекты регулируются политиками BLOB, позволяющими управлять использованием памяти и записью во временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). Здесь задаётся ограничение памяти для BLOB, разрешение или запрет временных файлов, корневой путь для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как найти баланс между скоростью и памятью?**

Да. Хранение BLOB в памяти максимизирует скорость, но повышает потребление ОЗУ; снижение лимита памяти переносит больше работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Отрегулируйте порог [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/), чтобы достичь нужного баланса для вашей нагрузки и среды.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайты)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника может существенно снизить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков, а не из файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, удерживая использование памяти предсказуемым во время обработки.