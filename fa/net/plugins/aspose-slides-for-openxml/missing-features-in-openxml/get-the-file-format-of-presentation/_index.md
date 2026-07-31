---
title: دریافت فرمت فایل ارائه
type: docs
weight: 50
url: /fa/net/get-the-file-format-of-presentation/
aliases:
  - /net/قالب-ارائه/
---
برای دریافت فرمت فایل. لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس **IPresentationInfo** ایجاد کنید
- اطلاعات مربوط به ارائه را دریافت کنید

در مثال زیر، فرمت فایل را دریافت کرده‌ایم.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **دریافت کد نمونه**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **دریافت مثال اجرایی**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)