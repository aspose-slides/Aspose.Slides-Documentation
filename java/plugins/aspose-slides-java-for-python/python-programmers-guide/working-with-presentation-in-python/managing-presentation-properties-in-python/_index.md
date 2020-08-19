---
title: Managing Presentation Properties in Python
type: docs
weight: 70
url: /java/managing-presentation-properties-in-python/
---

## **Aspose.Slides - Managing Presentation Properties**
To Manage Properties using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 def get_properties(self):

\# Instantiate the Presentation class that represents the presentation

pres = self.Presentation

pres = pres(self.dataDir + "HelloWorld.pptx")

\# Create a reference to IDocumentProperties object associated with Presentation

dp = pres.getDocumentProperties()

\# Display the builtin properties

print "Category : " + dp.getCategory() 

print "Current Status : " + dp.getContentStatus() 

print "Creation Date : "

print dp.getCreatedTime() 

print "Author : " + dp.getAuthor() 

print "Description : " + dp.getComments() 

print "KeyWords : " + dp.getKeywords() 

print "Last Modified By : " + dp.getLastSavedBy() 

print "Supervisor : " + dp.getManager() 

print "Modified Date : " 

print dp.getLastSavedTime() 

#print "Presentation Format : " + dp.getPresentationFormat() 

print "Last Print Date : "

print dp.getLastPrinted() 

print "Is Shared between producers : " 

print dp.getSharedDoc() 

print "Subject : " + dp.getSubject() 

print "Title : " + dp.getTitle()

def update_properties(self):

\# Instantiate the Presentation class that represents the presentation

pres = self.Presentation(self.dataDir + "HelloWorld.pptx")

\# Create a reference to IDocumentProperties object associated with Presentation

dp = pres.getDocumentProperties()

\# Set the builtin properties

dp.setAuthor ("Aspose.Slides for Java")

dp.setTitle ("Modifying Presentation Properties")

dp.setSubject ( "Aspose Subject")

dp.setComments ( "Aspose Description")

dp.setManager ( "Aspose Manager")

\# Save your presentation to a file

save_format = self.SaveFormat

pres.save(self.dataDir + "DocProps.pptx", save_format.Pptx)

print "Properties have been updated, Please check output file."

def add_custom_properties(self):

\# Instantiate the Presentation class that represents the presentation

pres = self.Presentation(self.dataDir + "HelloWorld.pptx")

\# Getting Document Properties

dp = pres.getDocumentProperties()

\# Adding Custom properties

dp.set_Item("self.Custom" , 12)

dp.set_Item("My Name","Mudassir")

dp.set_Item("Custom", 124)

\# Saving presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "CustomDemo.pptx", save_format.Pptx)

print "Added custom properties, please check output file."

def remove_property(self):

\# Instantiate the Presentation class that represents the presentation

pres = self.Presentation(self.dataDir + "HelloWorld.pptx")

\# Getting Document Properties

dp = pres.getDocumentProperties()

\# Getting property name at particular index

property_name = dp.getPropertyName(1)

\# Removing selected property

dp.remove(property_name)

\# Saving presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "RemoveDP.pptx", save_format.Pptx)

print "Remove document property, please check output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
