---
title: ".NET में लंबी अवधि वाले प्रेजेंटेशन ऑपरेशन को बाधित करें"
linktitle: "प्रेजेंटेशन ऑपरेशन को बाधित करें"
type: docs
weight: 150
url: /hi/net/support-for-interruptable-library/
keywords:
- "बाधित करने योग्य ऑपरेशन"
- "इंटरप्शन टोकन"
- "रद्दीकरण टोकन"
- "लंबे समय तक चलने वाला कार्य"
- "कार्य को बाधित करें"
- "PowerPoint"
- "OpenDocument"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET में लंबी अवधि वाले प्रेजेंटेशन ऑपरेशन को रद्द करने और लूप में स्लाइड्स निर्यात करते समय आंशिक परिणाम लौटाने के बारे में जानें।"
---
## **समीक्षा**

Aspose.Slides for .NET लंबे समय तक चलने वाले कार्यों जैसे कि लोड करना, सेव करना और प्रेजेंटेशन रेंडर करना को बाधित कर सकता है। आपका अनुप्रयोग अगला स्लाइड प्रोसेस करने से पहले लूप को रोकने के लिए वही इंटरप्शन टोकन उपयोग कर सकता है।

## **प्रेजेंटेशन ऑपरेशन को बाधित करें**

एक [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) बनाएँ, उसके [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) को [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) को असाइन करें, और लोड विकल्पों को [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) को पास करें। रद्दीकरण का अनुरोध करने के लिए, स्रोत पर [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) को कॉल करें। एक इंटरप्टेबल ऑपरेशन तब रुकता है जब वह अनुरोध को देखता है।

उदाहरण बैकग्राउंड टास्क में `sample.pptx` को `sample.ppt` में बदलना शुरू करता है और 10 सेकंड के बाद रद्दीकरण का अनुरोध करता है। यदि रूपांतरण पहले समाप्त हो जाता है, तो आउटपुट पहले ही पूर्ण हो जाता है।

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // एक अलग थ्रेड में क्रिया चलाएँ
    Thread.Sleep(10000);            // समय समाप्ति
    tokenSource.Interrupt();        // रूपांतरण रोकें
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET रद्दीकरण को Aspose.Slides से जोड़ें**

यदि आपका अनुप्रयोग एक .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) उपयोग करता है, तो उसकी रद्दीकरण अनुरोध को Aspose.Slides को अग्रेषित करें। उदाहरण `sample.pptx` को `sample.pdf` में निर्यात करना शुरू करता है और 20 सेकंड का टाइमआउट सेट करता है। निर्यात चलने के दौरान, यह हर 500 मिलीसेकंड में [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) को जांचता है। जब यह प्रॉपर्टी `true` हो जाती है, तो यह [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) को कॉल करता है।

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // क्रिया को एक अलग थ्रेड में चलाएँ

    while (!task.Wait(500)) // प्रतीक्षा करें और देखें कि cancellationToken.IsCancellationRequested सेट है या नहीं
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // Presentation प्रोसेसिंग को रोकें
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```

## **अगले स्लाइड को प्रोसेस करने से पहले रोकें**

प्रेजेंटेशन और उसके स्लाइड्स को निर्यात करने वाले लूप दोनों के लिए वही [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) उपयोग करें। प्रत्येक निर्यात शुरू करने से पहले [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) जाँचें। यदि कॉलर आंशिक परिणाम का उपयोग कर सकता है, तो सफलतापूर्वक पूर्ण हुए निर्यातों के स्लाइड नंबर वापस करें।

कम से कम दो स्लाइड्स वाले `sample.pptx` नामक प्रेजेंटेशन का उपयोग करें। उदाहरण पहले सफल निर्यात को रिकॉर्ड करने के तुरंत बाद रद्दीकरण का अनुरोध करता है।

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

उदाहरण `slide-1.pdf` लिखता है और `Starting slide 1` प्रिंट करता है, उसके बाद `Completed: [1]`। लूप स्लाइड 2 शुरू होने से पहले अनुरोध को देखता है। यदि रद्दीकरण निर्यात के दौरान [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) को बाधित करता है, तो `catch` ब्लॉक कोड को वर्तमान स्लाइड को पूर्ण के रूप में रिकॉर्ड करने से पहले लूप से बाहर निकल देता है।

यदि कॉलर को रद्दीकरण संभालना है, तो लूप के शीर्ष पर `if` जांच और उसका `break` को टोकन पर [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) कॉल से बदलें। निर्यात के आसपास का `try`/`catch` हटाएँ ताकि सेव के दौरान रद्दीकरण भी कॉलर तक पहुँचे। वही इनपुट उपयोग करने पर, उदाहरण केवल `Starting slide 1` प्रिंट करता है और `slide-1.pdf` लिखता है। दूसरे इटरेशन की शुरुआत में, कॉलर को निर्यात शुरू होने से पहले एक [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) मिलता है। मेथड कोई सूची वापस नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**मुझे रद्दीकरण कब अनुरोध करना चाहिए?**

जब कोई ऑपरेशन आपके समय सीमा से अधिक हो जाता है या आपका अनुप्रयोग परिणाम की अब आवश्यकता नहीं रखता तो रद्दीकरण अनुरोध करें।

**[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) के बीच अंतर क्या है?**

स्रोत आपके अनुप्रयोग को रद्दीकरण का अनुरोध करने देता है। टोकन Aspose.Slides और आपके अनुप्रयोग को उस अनुरोध की जाँच करने देता है।

**क्या मैं Aspose.Slides के साथ .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) का उपयोग कर सकता हूँ?**

हाँ। जब आपका .NET टोकन रद्दीकरण संकेत देता है, तो प्रेजेंटेशन से जुड़े स्रोत पर [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) को कॉल करें।

**मैं किस ऑपरेशन को बाधित कर सकता हूँ?**

आप लोडिंग, सेविंग और रेंडरिंग को बाधित कर सकते हैं। टोकन को [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) के माध्यम से [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) को पास करें। तब प्रेजेंटेशन बाद के ऑपरेशनों जैसे कि [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) के दौरान रद्दीकरण देख सकता है।

**क्या कोई ऑपरेशन तुरंत रुकता है?**

रद्दीकरण सहयोगी है। एक ऑपरेशन टोकन को नियमित रूप से जांचता है और जब वह अनुरोध देखता है तो रुक जाता है।

**यदि कोई ऑपरेशन समाप्त होने के बाद मैं [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) कॉल करूँ तो क्या होता है?**

पूरा हुआ ऑपरेशन अपना परिणाम बनाए रखता है।

**क्या कई ऑपरेशन एक [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) साझा कर सकते हैं?**

हाँ। [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) कॉल करने से उस स्रोत से टोकन उपयोग करने वाले प्रत्येक ऑपरेशन के लिए रद्दीकरण अनुरोध किया जाता है। प्रत्येक ऑपरेशन को स्वतंत्र रूप से रद्दीकरण करने के लिए अलग स्रोत उपयोग करें।