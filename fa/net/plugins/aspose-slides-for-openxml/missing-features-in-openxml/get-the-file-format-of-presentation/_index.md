---
title: دریافت فرمت فایل ارائه
type: docs
weight: 50
url: /fa/net/get-the-file-format-of-presentation/
---
برای دریافت فرمت فایل، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس **IPresentationInfo** ایجاد کنید
- اطلاعات درباره ارائه را دریافت کنید

در مثال زیر، فرمت فایل به دست آمده است.
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
## **دانلود کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **دانلود مثال اجرایی**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)