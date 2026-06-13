---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /fa/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML نامی برای یک خانواده از فرمت‌های مبتنی بر XML برای اسناد ارائه است. Office OpenXML (OOXML) فرمت مبتنی بر XML است که در برنامه‌های Microsoft Office 2007 معرفی شد. Office OpenXML یک فرمت حامل برای چندین زبان نشانه‌گذاری تخصصی مبتنی بر XML است. PresentationML زبان نشانه‌گذاری‌ای است که توسط Microsoft Office PowerPoint 2007 برای ذخیره اسناد استفاده می‌شود.

{{% /alert %}} 

## **PresentationML در Aspose.Slides برای PHP از طریق Java**
اسناد OOXML PresentationML به‌صورت فایل‌های PPTX، بسته‌های فشرده XML که مطابق با مشخصات [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) هستند، ارائه می‌شوند. Aspose.Slides برای PHP از طریق Java به‌طور گسترده‌ای از ایجاد، خواندن، دستکاری و نوشتن اسناد PresentationML پشتیبانی می‌کند. علاوه بر این، Aspose.Slides برای PHP از طریق Java قادر است اسناد PresentationML را به فرمت مستندی که به‌طور گسترده استفاده می‌شود مانند PDF صادر کند. این امکان به این دلیل است که Aspose.Slides برای PHP از طریق Java طوری طراحی شده است که اسناد ارائه را به‌طور جامع مدیریت کند و PresentationML در واقع ارائه داخلی اسناد را به‌صورت یک بسته فشرده XML نگهداری می‌کند.

**یک سند PPTX که توسط Aspose.Slides برای PHP از طریق Java تولید شده و در Microsoft PowerPoint باز شده است**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**مشاهده همان سند PPTX که توسط Aspose.Slides برای PHP از طریق Java تولید شده در یک فایل ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML باز است، چرا از Aspose.Slides برای PHP از طریق Java استفاده کنیم؟**
از آنجا که PresentationML مبتنی بر XML است، می‌توان برنامه‌هایی برای پردازش و تولید اسناد PresentationML با استفاده از کلاس‌های XML ساخت بدون اینکه به کتابخانه کلاس سوم شخص مانند Aspose.Slides برای PHP از طریق Java وابسته باشید. با این حال، استفاده از Aspose.Slides برای PHP از طریق Java نسبت به کلاس‌های XML مزایای متعددی دارد وقتی که با اسناد PresentationML کار می‌کنید.

مشخصات OOXML چند هزار صفحه است، بنابراین برای مدیریت صحیح اسناد PresentationML باید زمان و تلاش زیادی برای درک این فرمت صرف کنید. از سوی دیگر، با Aspose.Slides برای PHP از طریق Java، فقط از کلاس‌ها و متدها و خصوصیات آن‌ها استفاده می‌کنید تا عملیاتی را انجام دهید که اگر با کلاس‌های XML انجام شوند پیچیده به‌نظر می‌رسند.

برخی از ویژگی‌های Aspose.Slides که حتی هنگام کار با اسناد PresentationML از طریق کلاس‌های XML در دسترس نیستند عبارتند از:

- صادرات اسناد PPT به فرمت PDF.
- رندر اسلاید به هر قالب تصویری که توسط فریمورک Java پشتیبانی می‌شود.
- کپی خودکار مسترها از ارائه‌های منبع با استفاده از ویژگی کلونینگ.
- اعمال محافظت بر اشکال.

در زیر یک مثال از سند PresentationML با یک اسلاید تک که شامل یک جعبه متن با متن «Hello World» است، آورده شده است. برای خواندن متن با استفاده از کلاس‌های XML، باید برنامه‌ای بنویسید که این متن ساده را از قطعه زیر تجزیه‌تحلیل کند. Aspose.Slides این کار را برای شما انجام می‌دهد.

**XML**

``` xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">
  <p:cSld>
    <p:spTree>
      <p:nvGrpSpPr>
        <p:cNvPr id="1" name=""/>
        <p:cNvGrpSpPr/>
        <p:nvPr/>
      </p:nvGrpSpPr>
      <p:grpSpPr>
        <a:xfrm>
          <a:off x="0" y="0"/>
          <a:ext cx="0" cy="0"/>
          <a:chOff x="0" y="0"/>
          <a:chExt cx="0" cy="0"/>
        </a:xfrm></p:grpSpPr><p:sp>
          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>
          <p:cNvSpPr txBox="1"/>
            <p:nvPr/>
          </p:nvSpPr>
          <p:spPr>
            <a:xfrm>
              <a:off x="2819400" y="2590800"/>
              <a:ext cx="1297086" cy="369332"/>
            </a:xfrm>
            <a:prstGeom prst="rect">
              <a:avLst/>
            </a:prstGeom>
            <a:noFill/>
          </p:spPr>
          <p:txBody>
            <a:bodyPr wrap="none" rtlCol="0">
              <a:spAutoFit/>
            </a:bodyPr>
            <a:lstStyle/>
            <a:p>
              <a:r>
                <a:rPr lang="en-US"/>
                <a:t>Hello World
                </a:t>
              </a:r>
              <a:endParaRPr lang="en-US"/>
            </a:p>
          </p:txBody>
        </p:sp>
    </p:spTree>
  </p:cSld>
  <p:clrMapOvr>
    <a:masterClrMapping/>
  </p:clrMapOvr>
</p:sld>
```php
