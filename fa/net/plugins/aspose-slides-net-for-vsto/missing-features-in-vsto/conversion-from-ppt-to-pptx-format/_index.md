---
title: تبدیل از فرمت PPT به PPTX
type: docs
weight: 20
url: /fa/net/conversion-from-ppt-to-pptx-format/
---
ویژگی منحصر به‌فرد Aspose.Slides که انعطاف‌پذیری در تبدیل نسخه‌ها بدون تاثیر بر کار را فراهم می‌کند.
SaveFormat یک نوع شمارشی است که می‌تواند اسناد را به پسوندهای ذکر شده در جدول زیر تبدیل کند.

|**نام عضو**|**مقدار**|**توضیح**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |

در زیر نمونه کدی آورده شده است که تبدیل از PPT به PPTX را نشان می‌دهد؛ می‌توانید به صورت معکوس نیز انجام دهید.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//یک شی Presentation ایجاد می‌کند که نمایانگر فایل PPTX است

Presentation pres = new Presentation(srcFileName);

//ذخیره‌سازی ارائه PPTX به فرمت PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **کد نمونه را دانلود کنید**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [بیت‌باکت](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)