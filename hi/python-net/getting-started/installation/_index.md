---
title: स्थापना
type: docs
weight: 70
url: /hi/python-net/installation/
keywords:
- Aspose.Slides डाउनलोड करें
- Aspose.Slides स्थापित करें
- Aspose.Slides का उपयोग करें
- Aspose.Slides स्थापना
- pip
- PyPI
- विंडोज़
- लिनक्स
- मैकोस
- पायथन
description: "PyPI से pip का उपयोग करके Windows, Linux और macOS पर .NET के माध्यम से Python के लिए Aspose.Slides स्थापित करें, और Linux और macOS को आवश्यक मूल पुस्तकालय स्थापित करें।"
---
## **परिचय**

यह लेख बताता है कि Windows, Linux और macOS पर .NET के माध्यम से Python के लिए Aspose.Slides कैसे स्थापित करें। पैकेज [PyPI](https://pypi.org/project/aspose.slides/) पर प्रकाशित है और pip के साथ स्थापित किया जाता है। इसमें वह .NET रनटाइम शामिल है जो यह उपयोग करता है, इसलिए आपको .NET स्थापित करने की आवश्यकता नहीं है। Linux और macOS पर, उस रनटाइम को मूल पुस्तकालयों की आवश्यकता होती है जो ऑपरेटिंग सिस्टम संभवतः नहीं प्रदान करता; नीचे के अनुभाग इन्हें नामित करते हैं।

Aspose.Slides for Python via .NET Python 3.5 से 3.14 का समर्थन करता है। PyPI Windows (32-बिट और 64-बिट), Linux (x86_64 और ARM64), और macOS (Intel और Apple silicon) के लिए पैकेज उपलब्ध कराता है।

## **Windows**

Windows पर, पैकेज को pip के साथ स्थापित करें। अन्य कोई पुस्तकालय आवश्यक नहीं हैं।

```bash
pip install aspose.slides
```

## **Linux**

Linux पर, पैकेज में शामिल .NET रनटाइम को दो पुस्तकालयों की आवश्यकता होती है:

- **libgdiplus**, Windows GDI+ ग्राफ़िक्स API का एक कार्यान्वयन। इसके बिना, प्रस्तुति को सहेजने पर त्रुटि `The type initializer for 'Gdip' threw an exception` आती है।
- **ICU** (International Components for Unicode)। इसके बिना, पहली Aspose.Slides कॉल पर Python प्रक्रिया समाप्त हो जाती है और संदेश `Couldn't find a valid ICU package installed on the system` दिखाता है।

Debian और Ubuntu पर, दोनों को apt के साथ स्थापित करें:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

ICU पैकेज का नाम उसके संस्करण को दर्शाता है: `libicu76` Debian 13 के लिए पैकेज है। Debian 12 पर, `libicu72` स्थापित करें, और Ubuntu 24.04 पर `libicu74`। अपने सिस्टम पर नाम जानने के लिए, चलाएँ:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

फिर पैकेज को एक वर्चुअल एन्वायरनमेंट में स्थापित करें। वर्तमान Debian और Ubuntu रिलीज़ में, सिस्टम Python वर्चुअल एन्वायरनमेंट के बाहर `pip install` की अनुमति नहीं देता और `externally-managed-environment` त्रुटि के साथ रुक जाता है।

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

अपने स्क्रिप्ट्स को उसी वर्चुअल एन्वायरनमेंट को सक्रिय करके चलाएँ। यदि आप वह Python उपयोग करते हैं जिसे आपका वितरण प्रबंधित नहीं करता, जैसे आधिकारिक `python` Docker छवियों में, तो आप वर्चुअल एन्वायरनमेंट के बिना भी `pip install aspose.slides` चला सकते हैं।

आपकी प्रस्तुतियों में प्रयुक्त फ़ॉन्ट्स, या उनके उपयुक्त विकल्प, सिस्टम में स्थापित होने चाहिए ताकि स्लाइड्स को PDF या छवियों में परिवर्तित करते समय पाठ सही रूप से प्रदर्शित हो।

## **macOS**

हमने macOS पर स्थापना की पुष्टि नहीं की है। macOS पर, Aspose.Slides को निम्न पूर्वापेक्षाएँ चाहिए:

- **Python with shared libraries**, अर्थात् वह Python जो `--enable-shared` कॉन्फ़िगर विकल्प के साथ निर्मित है। यदि आप Python को [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos) के साथ स्थापित करते हैं, तो Python संस्करण स्थापित करते समय `PYTHON_CONFIGURE_OPTS` पर्यावरण चर को `--enable-shared` सेट करें।
- **The libpython library in a system library directory.** pyenv के साथ स्थापित Python अपनी libpython लाइब्रेरी, जैसे *libpython3.9.dylib*, को *~/.pyenv/versions* में रखता है; इसे */usr/local/lib* में एक सिम्बॉलिक लिंक बनाएं।
- **libgdiplus**, Windows GDI+ ग्राफ़िक्स API का एक कार्यान्वयन। Homebrew इसे `mono-libgdiplus` पैकेज के रूप में प्रदान करता है।

फिर पैकेज को pip के साथ स्थापित करें।

## **स्थापना की जाँच**

स्थापना की जाँच के लिए, पहले उदाहरण को [Create Presentations](/slides/hi/python-net/create-presentation/) में *hello.py* के रूप में सहेजें और `python hello.py` चलाएँ। यह वर्तमान फ़ोल्डर में *new_presentation.pptx* सहेजता है।

## **अपग्रेड**

मौजूदा स्थापना को नवीनतम संस्करण में अपग्रेड करने के लिए, उस वातावरण में यह कमांड चलाएँ जहाँ आपने पैकेज स्थापित किया था:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Can I install Aspose.Slides in a virtual environment?**

हाँ। आप इसे किसी भी Python वर्चुअल एन्वायरनमेंट में pip के साथ स्थापित कर सकते हैं। Linux और macOS को आवश्यक मूल पुस्तकालय सिस्टम पर स्थापित होते हैं, वर्चुअल एन्वायरनमेंट में नहीं।

**Can I use Aspose.Slides in Docker containers?**

हाँ। इमेज में Linux सिस्टम के समान मूल पुस्तकालय — libgdiplus और ICU — तथा आपके प्रस्तुतियों द्वारा उपयोग किए गए फ़ॉन्ट्स होने चाहिए।

**Is there a free version or trial limitation?**

हाँ। लाइसेंस के बिना, Aspose.Slides मूल्यांकन मोड में चलता है: यह प्रत्येक सहेजी गई स्लाइड में मूल्यांकन वॉटरमार्क जोड़ता है और प्रस्तुतियों से पढ़े गए पाठ को काट देता है। इन प्रतिबंधों को हटाने के लिए, एक वैध [license](/slides/hi/python-net/licensing/) लागू करें।