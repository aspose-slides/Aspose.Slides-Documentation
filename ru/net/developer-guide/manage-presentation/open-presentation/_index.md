---
title: Открыть презентацию в C#
linktitle: Открыть презентацию
type: docs
weight: 20
url: /net/open-presentation/
keywords: "Открыть PowerPoint, PPTX, PPT, Открыть презентацию, Загрузить презентацию, C#, Csharp, .NET"
description: "Открыть или загрузить презентацию PPT, PPTX, ODP на C# или .NET"
---

Кроме создания презентаций PowerPoint с нуля, Aspose.Slides позволяет вам открывать существующие презентации. После загрузки презентации вы можете получить информацию о ней, редактировать ее (содержимое на слайдах), добавлять новые слайды или удалять существующие и т.д.

## Открыть презентацию

Чтобы открыть существующую презентацию, вам просто нужно создать экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и передать путь к файлу (к презентации, которую вы хотите открыть) в его конструктор.

Этот код на C# показывает, как открыть презентацию и узнать, сколько слайдов она содержит:

```c#
// Создание экземпляра класса Presentation и передача пути к файлу в его конструктор
Presentation pres = new Presentation("OpenPresentation.pptx");

// Выводит общее количество слайдов в презентации
System.Console.WriteLine(pres.Slides.Count.ToString());
```

## **Открыть защищенную паролем презентацию**

Когда вам нужно открыть презентацию с защитой паролем, вы можете передать пароль через свойство [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) (из класса [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)), чтобы расшифровать и загрузить презентацию. Этот код на C# демонстрирует операцию:

```c#
	LoadOptions loadOptions = new LoadOptions {Password = "ВАШ_ПАРОЛЬ"};
	using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
	{
	  // Выполните некоторые действия с расшифрованной презентацией
	}
```

## Открыть большую презентацию

Aspose.Slides предоставляет параметры (в частности, свойство [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) в классе [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)), позволяющие загружать большие презентации.

Этот код на C# демонстрирует операцию, в которой загружается большая презентация (например, размером 2 ГБ):

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // Давайте выберем поведение KeepLocked - "veryLargePresentation.pptx" будет заблокирован на
        // время существования экземпляра Presentation, но нам не нужно загружать его в память или копировать в
        // временный файл
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // Большая презентация загружена и может быть использована, но потребление памяти все еще низкое.

    // Внесение изменений в презентацию.
    pres.Slides[0].Name = "Очень большая презентация";

    // Презентация будет сохранена в другой файл. Потребление памяти остается низким во время операции
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // Нельзя это сделать! Будет выброшено исключение IO, так как файл заблокирован, пока объекты pres не будут
    // освобождены
    File.Delete(pathToVeryLargePresentationFile);
}

// Здесь можно сделать это, исходный файл не заблокирован объектом pres
File.Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Информация" %}}

Чтобы обойти определенные ограничения при взаимодействии с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через ее поток приведет к копированию содержимого презентации и замедлит загрузку. Поэтому, когда вы собираетесь загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не её поток.

Когда вы хотите создать презентацию, содержащую большие объекты (видео, аудио, большие изображения и т.д.), вы можете использовать [Blob-объекты](https://docs.aspose.com/slides/net/manage-blob/), чтобы уменьшить потребление памяти.

{{%/alert %}}

## Загрузить презентацию
Aspose.Slides предоставляет [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) с единственным методом, позволяющим управлять внешними ресурсами. Этот код на C# показывает, как использовать интерфейс `IResourceLoadingCallback`:

```c#
LoadOptions opts = new LoadOptions();
opts.ResourceLoadingCallback = new ImageLoadingHandler();
Presentation presentation = new Presentation("presentation.pptx", opts);
```

```c#
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try // Загружает заменяющее изображение
            {
                byte[] imageBytes = File.ReadAllBytes("c:\\aspose-logo.jpg");
                args.SetData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Устанавливает заменяющий URL
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Пропускает все остальные изображения
        return ResourceLoadingAction.Skip;
    }
}
```

## Загрузить презентацию без встроенных двоичных объектов

Презентация PowerPoint может содержать следующие виды встроенных двоичных объектов:

- VBA проект ([IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- Встроенные данные OLE объектов ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Двоичные данные ActiveX управления ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/));

Используя свойство [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/), вы можете загрузить презентацию без каких-либо встроенных двоичных объектов.

Это свойство может быть полезно для удаления потенциально вредоносного двоичного содержимого.

Код на C# демонстрирует, как загрузить и сохранить презентацию без вредоносного содержимого:

```c#
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (var pres = new Presentation("malware.ppt", loadOptions))
{
    pres.Save("clean.ppt", SaveFormat.Ppt);
}
```

<h2>Открыть и сохранить презентацию</h2>

<a name="csharp-open-save-presentation"><strong>Этапы: Открыть и сохранить презентацию в C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и передайте файл, который вы хотите открыть.
2. Сохраните презентацию.

```c#
// Загружает любую поддерживаемую презентацию, например ppt, pptx, odp
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```